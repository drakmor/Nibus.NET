namespace NataInfo.Nibus.Sport
{
    /// <summary>
    /// �������� �������� �� ��������� ���������� �� ���������.
    /// </summary>
    public sealed class PenaltyStatChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� ������� ���������� �� ���������.
        /// </summary>
        public PenaltyStat PenaltyStat { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PenaltyStatChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="penaltyStat">���������� �� ���������.</param>
        public PenaltyStatChangedEventArgs(Address source, PenaltyStat penaltyStat)
            : base(source)
        {
            PenaltyStat = penaltyStat;
        }
    }
}