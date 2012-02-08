using System;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace NataInfo.Nibus.Sport
{
    /// <summary>
    /// ������� ����������� ����� ��� �������� � ������� ��������� ���������� �������������� ���������.
    /// </summary>
    public abstract class BaseInformationReportEventArgs : EventArgs
    {
        /// <summary>
        /// ���������� ����� ��������� ���������.
        /// </summary>
        public Address Source { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseInformationReportEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ��������� ���������.</param>
        protected BaseInformationReportEventArgs(Address source)
        {
            Source = source;
        }
    }

    /// <summary>
    /// �������� �������� �� ��������� �������.
    /// </summary>
    public sealed class TimerChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="timer">���������� �������.</param>
        public TimerChangedEventArgs(Address source, TimerInfo timer) : base(source)
        {
            Timer = timer;
        }

        /// <summary>
        /// ���������� ���������� � �������.
        /// </summary>
        public TimerInfo Timer { get; private set; }
    }

    /// <summary>
    /// �������� �������� �� ��������� �����.
    /// </summary>
    public sealed class ScoreChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="score">���������� �����.</param>
        public ScoreChangedEventArgs(Address source, ushort score)
            : base(source)
        {
            Score = score;
        }

        /// <summary>
        /// ���������� ���������� �����.
        /// </summary>
        public ushort Score { get; private set; }
    }

    /// <summary>
    /// �������� �������� �� ��������� �������.
    /// </summary>
    public sealed class PeriodChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeriodChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="period">������.</param>
        public PeriodChangedEventArgs(Address source, byte period)
            : base(source)
        {
            Period = period;
        }

        /// <summary>
        /// ���������� ������.
        /// </summary>
        public byte Period { get; private set; }
    }

    /// <summary>
    /// �������� ���������� ��������� 
    /// </summary>
    public sealed class FoulsChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoulsChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="fouls">���������� �����.</param>
        public FoulsChangedEventArgs(Address source, byte fouls)
            : base(source)
        {
            Fouls = fouls;
        }

        /// <summary>
        /// ���������� ���������� �����.
        /// </summary>
        public byte Fouls { get; private set; }
    }

    /// <summary>
    /// �������� �������� �� ��������� 
    /// </summary>
    public sealed class TimebreaksChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimebreaksChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="timebreaks">���������� ���������.</param>
        public TimebreaksChangedEventArgs(Address source, byte timebreaks)
            : base(source)
        {
            Timebreaks = timebreaks;
        }

        /// <summary>
        /// ���������� ���������� ���������.
        /// </summary>
        public byte Timebreaks { get; private set; }
    }

    /// <summary>
    /// �������� �������� �� ��������� 
    /// </summary>
    public sealed class TeamCountChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TeamCountChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="role">�������������� �������.</param>
        /// <param name="count">���������� ������ �������.</param>
        public TeamCountChangedEventArgs(Address source, TeamRole role, ushort count)
            : base(source)
        {
            Role = role;
            Count = count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamCountChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="nmsData">������ NMS.</param>
        internal TeamCountChangedEventArgs(Address source, object nmsData)
            : base(source)
        {
            var data = (byte[])nmsData;
            Role = (TeamRole)data[0];
            Count = BitConverter.ToUInt16(data, 1);
        }

        /// <summary>
        /// ���������� �������������� �������.
        /// </summary>
        public TeamRole Role { get; private set; }
        /// <summary>
        /// ���������� ���������� ������ �������.
        /// </summary>
        public ushort Count { get; private set; }
    }

    /// <summary>
    /// �������� �������� �� ��������� ���������� �� ������. 
    /// </summary>
    public sealed class PlayerInfoChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� ���������� �� ������.
        /// </summary>
        public PlayerInfo Info { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerInfoChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="info">���������� �� ������.</param>
        public PlayerInfoChangedEventArgs(Address source, PlayerInfo info)
            : base(source)
        {
            Info = info;
        }
    }

    /// <summary>
    /// �������� �������� �� ��������� ���������� ������ (���������).
    /// </summary>
    public sealed class PlayerStatChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� ���������� �� ������.
        /// </summary>
        public PlayerStat Stat { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerStatChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="stat">���������� �� �����.</param>
        public PlayerStatChangedEventArgs(Address source, PlayerStat stat)
            : base(source)
        {
            Stat = stat;
        }
    }

    /// <summary>
    /// �������� �������� �� ��������� �������� �������.
    /// </summary>
    public sealed class TeamNameChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� �������� �������.
        /// </summary>
        public string TeamName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamNameChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="teamName">�������� �������.</param>
        public TeamNameChangedEventArgs(Address source, string teamName)
            : base(source)
        {
            TeamName = teamName;
        }
    }

    /// <summary>
    /// �������� �������� �� ��������� ������/������ � �������.
    /// </summary>
    public sealed class CountryChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� ������/����� � �������.
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="country">�������� ������/������.</param>
        public CountryChangedEventArgs(Address source, string country)
            : base(source)
        {
            Country = country;
        }
    }

    /// <summary>
    /// �������� �������� �� ��������� �������� �������.
    /// </summary>
    public sealed class TournamentChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� �������� �������.
        /// </summary>
        public string Tournament { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TournamentChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="tournament">�������� �������.</param>
        public TournamentChangedEventArgs(Address source, string tournament)
            : base(source)
        {
            Tournament = tournament;
        }
    }

    /// <summary>
    /// �������� �������� �� ��������� �������� �����.
    /// </summary>
    public sealed class BallOwnerChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� ��������� �������� �����.
        /// </summary>
        public BallOwner BallOwner { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BallOwnerChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="ballOwner">��������� �����.</param>
        public BallOwnerChangedEventArgs(Address source, BallOwner ballOwner)
            : base(source)
        {
            BallOwner = ballOwner;
        }
    }

    /// <summary>
    /// �������� �������� � ������������� ������ ��������������� ��������� �� �����.
    /// </summary>
    public sealed class ShowInfoMessageEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� �������������� ���������.
        /// </summary>
        public InfoMessage InfoMessage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowInfoMessageEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="infoMessage">�������������� ���������.</param>
        public ShowInfoMessageEventArgs(Address source, InfoMessage infoMessage)
            : base(source)
        {
            InfoMessage = infoMessage;
        }
    }

    /// <summary>
    /// �������� �������� �� ��������� ���������� ���� (���� ������).
    /// </summary>
    public sealed class SportChangedEventArgs : BaseInformationReportEventArgs
    {
        /// <summary>
        /// ���������� ���������� ����.
        /// </summary>
        public ProviderInfo ProviderInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SportChangedEventArgs"/> class.
        /// </summary>
        /// <param name="source">����� ���������.</param>
        /// <param name="providerInfo">��������� ����.</param>
        public SportChangedEventArgs(Address source, ProviderInfo providerInfo)
            : base(source)
        {
            ProviderInfo = providerInfo;
        }
    }
}