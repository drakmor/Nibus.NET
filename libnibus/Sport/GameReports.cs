namespace NataInfo.Nibus.Sport
{
    /// <summary>
    /// ����� ������� �������.
    /// </summary>
    public enum GameReports
    {
        /// <summary>
        /// ������� �������.
        /// </summary>
        Timer = 5,

        /// <summary>
        /// ���� ������� ������.
        /// </summary>
        HomeTeamScore = 6,

        /// <summary>
        /// ���� ������� ������.
        /// </summary>
        VisitingTeamScore = 7,

        /// <summary>
        /// ������.
        /// </summary>
        Period = 8,

        /// <summary>
        /// ���������� ����� ������� ������.
        /// </summary>
        HomeTeamFouls = 9,

        /// <summary>
        /// ���������� ����� ������� ������.
        /// </summary>
        VisitingTeamFouls = 10,

        /// <summary>
        /// ���������� ��������� ������� ������.
        /// </summary>
        HomeTeamTimebreaks = 14,

        /// <summary>
        /// ���������� ��������� ������� ������.
        /// </summary>
        VisitingTeamTimebreaks = 15,

        /// <summary>
        /// ���������� ������� � �������.
        /// </summary>
        TeamCount = 16,

        /// <summary>
        /// ���������� � ������.
        /// </summary>
        PlayerInfo = 17,

        /// <summary>
        /// ���������� �� ������.
        /// </summary>
        PlayerStat = 18,

        /// <summary>
        /// �������� ������� ������.
        /// </summary>
        HomeTeamName = 19,

        /// <summary>
        /// �������� ������� ������.
        /// </summary>
        VisitingTeamName = 20,

        /// <summary>
        /// �����/������ ������� ������.
        /// </summary>
        HomeTeamCountry = 21,

        /// <summary>
        /// �����/������ ������� ������.
        /// </summary>
        VisitingTeamCountry = 22,

        /// <summary>
        /// �������� �������.
        /// </summary>
        TournamentName = 23,

        /// <summary>
        /// ��������� �������� �����.
        /// </summary>
        BallOwner = 24,

        /// <summary>
        /// ����� ��������������� ���������.
        /// </summary>
        ShowMessage = 25,

        /// <summary>
        /// ������������ ���������� ���� (����� ���� ������).
        /// </summary>
        ChangeSport = 27
    }

    /// <summary>
    /// �������������� � �������.
    /// </summary>
    public enum TeamRole : byte
    {
        /// <summary>
        /// ������� ������.
        /// </summary>
        Home = 0,

        /// <summary>
        /// ������� ������.
        /// </summary>
        Visitor = 1,

        /// <summary>
        /// �����.
        /// </summary>
        Judge = 2
    }

    /// <summary>
    /// ������� ����� �������.
    /// </summary>
    public enum PlayerFunction : byte
    {
        /// <summary>
        /// ������� �����.
        /// </summary>
        Team = 0,

        /// <summary>
        /// �������� �����.
        /// </summary>
        Reserve = 1,

        /// <summary>
        /// ������� �������.
        /// </summary>
        Captain = 2,

        /// <summary>
        /// ������.
        /// </summary>
        Coach = 3
    }

    /// <summary>
    /// ��������� �������� ����� (����������� ������).
    /// </summary>
    public enum BallOwner : byte
    {
        /// <summary>
        /// ������ ��������� ������ (����������� ������������).
        /// </summary>
        Hidden = 0,

        /// <summary>
        /// ��� (������) � ������� ������.
        /// </summary>
        Home = 1,

        /// <summary>
        /// ��� (������) � ������� ������.
        /// </summary>
        Visitor = 2
    }
}