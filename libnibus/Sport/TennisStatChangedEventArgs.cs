namespace NataInfo.Nibus.Sport
{
    /// <summary>
    /// �������� �������� �� ��������� ���������� �� �������.
    /// </summary>
    public sealed class TennisStatChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� ���������� �� �������.
        /// </summary>
        public TennisStat TennisStat { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TennisStatChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="tennisStat">����������.</param>
        public TennisStatChangedEventArgs(Address source, TennisStat tennisStat) : base(source)
        {
            TennisStat = tennisStat;
        }
    }
}