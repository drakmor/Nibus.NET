using System;

namespace NataInfo.Nibus.Nms
{
    /// <summary>
    /// ����� ���������� ������ � ������� ��������� ��������������� ���������.
    /// </summary>
    public class NmsInformationReportEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NmsInformationReportEventArgs"/> class.
        /// </summary>
        /// <param name="report">�������������� ���������.</param>
        public NmsInformationReportEventArgs(NmsInformationReport report)
        {
            InformationReport = report;
        }

        /// <summary>
        /// ���������� �������������� ���������.
        /// </summary>
        public NmsInformationReport InformationReport { get; private set; }

        /// <summary>
        /// ���������, ��� ��������� ���� ���������������� � � ������ �������� �� ���� - ����������.
        /// </summary>
        public bool Identified { get; set; }
    }
}