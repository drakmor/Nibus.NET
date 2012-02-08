using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using NataInfo.Nibus.Nms;
using NataInfo.Nibus.Nms.Services;

namespace NataInfo.Nibus.Sport
{
    /// <summary>
    /// ���������� �� ������.
    /// </summary>
    public sealed class PlayerInfo
    {
        private const int RoleOfs = 0;
        private const int IndexOfs = 2;
        private const int NumberOfs = 3;
        private const int FunctionOfs = 4;
        private const int TextOfs = 5;
        private const int NameMaxLength = 30;
        private const int CountryMaxLength = 20;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerInfo"/> class.
        /// </summary>
        /// <param name="role">�������������� �������.</param>
        /// <param name="index">������ � ������ (���������� � 0).</param>
        /// <param name="number">����� ������.</param>
        /// <param name="function">������� ������ � �������.</param>
        /// <param name="name">��� ������.</param>
        /// <param name="country">������/�����.</param>
        /// <param name="info">�������������� ����������.</param>
        public PlayerInfo(
            TeamRole role,
            int index,
            int number,
            PlayerFunction function,
            string name,
            string country,
            string info)
        {
            Role = role;
            Index = index;
            Number = number;
            Function = function;
            Name = name ?? string.Empty;
            Country = country ?? string.Empty;
            Info = info ?? string.Empty;
        }

        internal PlayerInfo(IList<byte> nmsData)
        {
            Role = (TeamRole)nmsData[RoleOfs];
            Index = nmsData[IndexOfs];
            Number = NmsMessage.UnpackByte(nmsData[NumberOfs]);
            Function = (PlayerFunction)nmsData[FunctionOfs];
            var i = 0;
            var splits = from b in nmsData.Skip(TextOfs)
                         group b by b == 0 ? i++ : i
                         into part
                         select Encoding.Default.GetString(part.TakeWhile(b => b != 0).ToArray());
            var lines = splits.Take(3).ToArray();
            Contract.Assume(lines.Length == 3);
            Name = lines[0];
            Country = lines[1];
            Info = lines[2];
        }

        /// <summary>
        /// ���������� �������������� � �������.
        /// </summary>
        public TeamRole Role { get; private set; }

        /// <summary>
        /// ���������� ������ ������ � ������.
        /// </summary>
        /// <remarks>��������� ���������� � <c>0</c>.</remarks>
        public int Index { get; private set; }

        /// <summary>
        /// ���������� ����� ������.
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// ������� ������.
        /// </summary>
        public PlayerFunction Function { get; private set; }

        /// <summary>
        /// ������� ������.
        /// </summary>
        /// <remarks>�� ����� 30 ��������.</remarks>
        public string Name { get; private set; }

        /// <summary>
        /// ������/�����.
        /// </summary>
        /// <remarks>�� ����� 20 ��������.</remarks>
        public string Country { get; private set; }

        /// <summary>
        /// ���������� �������������� ���������� �� ������.
        /// </summary>
        /// <remarks>
        /// ������������ ����� <see cref="NmsMessage.NmsMaxDataLength"/> ����� ����� <see cref="Name"/>
        /// ����� ����� <see cref="Country"/> ����� 9.</remarks>
        public string Info { get; private set; }

        internal byte[] GetData()
        {
            var text = new List<byte>(Name.Length + Country.Length + Info.Length + 3);
            text.AddRange(Encoding.Default.GetBytes(Name).Take(NameMaxLength));
            text.Add(0);
            text.AddRange(Encoding.Default.GetBytes(Country).Take(CountryMaxLength));
            text.Add(0);
            var rest = NmsMessage.NmsMaxDataLength - text.Count - (TextOfs + 1) - 1;
            text.AddRange(Encoding.Default.GetBytes(Info).Take(rest));
            text.Add(0);

            var data = new byte[(TextOfs + 1) + text.Count];

            data[RoleOfs] = (byte)Role;
            data[IndexOfs] = (byte)Index;
            data[NumberOfs] = NmsMessage.PackByte(Number);
            data[FunctionOfs] = (byte)Function;
            text.CopyTo(data, TextOfs);

            return data;
        }
    }

    /// <summary>
    /// ���������� ��� ����������� ���������� �� ������.
    /// </summary>
    internal static class PlayerInfoExtensions
    {
        public static NmsInformationReport CreateInformationReport(this PlayerInfo info, Address source = null)
        {
            return new NmsInformationReport(
                source ?? Address.Empty,
                (int)GameReports.PlayerInfo,
                NmsValueType.UInt8Array,
                info.GetData());
        }

        public static PlayerInfo GetPlayerInfo(this NmsInformationReport report)
        {
            Contract.Requires(report.Id == (byte)GameReports.PlayerInfo);
            return new PlayerInfo((byte[])report.Value);
        }
    }
}