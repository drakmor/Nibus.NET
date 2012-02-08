using System;
using System.Collections.Generic;
using System.Linq;
using NataInfo.Nibus.Nms.Services;

namespace NataInfo.Nibus.Sport
{
    /// <summary>
    /// ���������� �� ��������� ������ (������).
    /// </summary>
    public class PenaltyInfo
    {
        private const int AttrOfs = 0;
        private const int NumberOfs = 1;
        private const int MinutesOfs = 2;
        private const int SecondsOfs = 3;
        private const int ReservedOfs = 4;
        internal const int ItemLength = 5;

        [Flags]
        private enum Attributes : byte
        {
            None = 0,
            Valid = 1,
            Active = 2
        }

        /// <summary>
        /// ����� ������
        /// </summary>
        public int PlayerNo { get; set; }

        /// <summary>
        /// ���������� �������� �����.
        /// </summary>
        public int Minutes { get; set; }

        /// <summary>
        /// ���������� �������� ������.
        /// </summary>
        public int Seconds { get; set; }

        /// <summary>
        /// ���������� ����� ���������� �� �����.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// ������������ ������ ��������� �������.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PenaltyInfo"/> class.
        /// </summary>
        /// <param name="playerNo">����� ������.</param>
        /// <param name="minutes">�������� ������.</param>
        /// <param name="seconds">�������� �������.</param>
        /// <param name="isValid"><c>true</c> - ���������� ������ � ������.</param>
        /// <param name="isActive"><c>true</c> - ������ �����������.</param>
        public PenaltyInfo(int playerNo, int minutes, int seconds, bool isValid = true, bool isActive = true)
        {
            PlayerNo = playerNo;
            Minutes = minutes;
            Seconds = seconds;
            IsValid = isValid;
            IsActive = isActive;
        }

        internal PenaltyInfo(IEnumerable<byte> data)
        {
            var adata = data.ToArray();
            IsValid = (adata[AttrOfs] & (byte)Attributes.Valid) != 0;
            IsActive = (adata[AttrOfs] & (byte)Attributes.Active) != 0;
            PlayerNo = NmsMessage.UnpackByte(adata[NumberOfs]);
            Minutes = NmsMessage.UnpackByte(adata[MinutesOfs]);
            Seconds = NmsMessage.UnpackByte(adata[SecondsOfs]);
        }

        /// <summary>
        /// ���������� ��������� ������������� ��� ��������.
        /// </summary>
        /// <returns>
        /// ������ � ������� "NN MM:SS": �����, ������, �������.
        /// </returns>
        public override string ToString()
        {
            return String.Format("{0:D2} {1:D2}:{2:D2}", PlayerNo, Minutes, Seconds);
        }

        internal byte[] GetData()
        {
            var data = new byte[ItemLength];
            data[AttrOfs] =
                (byte)
                ((IsActive ? Attributes.Active : Attributes.None) | (IsValid ? Attributes.Valid : Attributes.None));
            data[NumberOfs] = NmsMessage.PackByte(PlayerNo);
            data[MinutesOfs] = NmsMessage.PackByte(Minutes);
            data[SecondsOfs] = NmsMessage.PackByte(Seconds);
            return data;
        }
    }
}