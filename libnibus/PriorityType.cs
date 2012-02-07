namespace NataInfo.Nibus
{
    /// <summary>
    /// ��������� ���������. ����������� ��� ���������.
    /// </summary>
    public enum PriorityType
    {
        /// <summary>
        /// ��������� ���������.
        /// </summary>
        Realtime = 0,

        /// <summary>
        /// ��������� ���� �����������.
        /// </summary>
        AboveNormal = 1,

        /// <summary>
        /// ���������� ���������.
        /// </summary>
        Normal = 2,

        /// <summary>
        /// ������ ���������.
        /// </summary>
        BelowNormal = 3
    }
}