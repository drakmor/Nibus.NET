namespace NataInfo.Nibus.Nms
{
    /// <summary>
    /// �������������� ���� ������� NMS.
    /// </summary>
    public enum NmsServiceType
    {
        /// <summary>
        /// ������� �������������� NMS-���������.
        /// ������ ��� ����������� �������������.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// ������������ � �������� ���������� <see cref="NmsReadMany"/>
        /// </summary>
        None = 0,
        /// <summary>
        /// ��������� �������� ����������.
        /// </summary>
        Read = 1,
        /// <summary>
        /// �������� �������� ����������.
        /// </summary>
        Write = 2,
        /// <summary>
        /// ��������������� �������� ����������.
        /// </summary>
        InformationReport = 3,
        /// <summary>
        /// ������������ �������.
        /// </summary>
        EventNotification = 4,
        /// <summary>
        /// ������������� �������.
        /// </summary>
        AckEventNotification = 5,
        /// <summary>
        /// ������/���������� ������������ �������.
        /// </summary>
        AlterEventConditionMonitoring = 6,
        /// <summary>
        /// ������ �� ���������� ������.
        /// </summary>
        RequestDomainUpload = 7,
        /// <summary>
        /// ������ ����������.
        /// </summary>
        InitiateUploadSequence = 8,
        /// <summary>
        /// ���������� ������ �� ����������.
        /// </summary>
        UploadSegment = 9,
        /// <summary>
        /// ������ �� �������� ������.
        /// </summary>
        RequestDomainDownload = 10,
        /// <summary>
        /// ������ ��������.
        /// </summary>
        InitiateDownloadSequence = 11,
        /// <summary>
        /// �������� ������ � ����������.
        /// </summary>
        DownloadSegment = 12,
        TerminateDownloadSequence = 13,
        /// <summary>
        /// �������� ����������� ����� ������.
        /// </summary>
        VerifyDomainChecksum = 14,
        /// <summary>
        /// ��������� ���������.
        /// </summary>
        ExecuteProgramInvocation = 15,
        /// <summary>
        /// ������ ���������� ���������.
        /// </summary>
        StartProgramInvocation = 16,
        /// <summary>
        /// ���������� ���������.
        /// </summary>
        Stop = 17,
        /// <summary>
        /// ���������� ����������.
        /// </summary>
        Resume = 18,
        /// <summary>
        /// ��������������� ���������.
        /// </summary>
        Reset = 19,
        /// <summary>
        /// ���������� ����������.
        /// </summary>
        Shutdown = 20
    }
}