namespace NataInfo.Nibus.Nms
{
    /// <summary>
    /// ���� ��������, ������������ � NMS-����������.
    /// </summary>
    public enum NmsValueType : byte
    {
        /// <summary>
        /// ���������� ���. 8 ��� �������� TRUE = 1/FALSE = 0
        /// </summary>
        Boolean = 11,

        /// <summary>
        /// ���� �� ������. 8 ���.
        /// </summary>
        Int8 = 16,

        /// <summary>
        /// �������� �������� �����. 16 ���.
        /// </summary>
        Int16 = 2,

        /// <summary>
        /// �������� �����. 32 ����.
        /// </summary>
        Int32 = 3,

        /// <summary>
        /// �������� ������� �����. 64 ����.
        /// </summary>
        Int64 = 20, // 
        /// <summary>
        /// ����. 8 ���.
        /// </summary>
        UInt8 = 17,

        /// <summary>
        /// �������� �����. 16 ���.
        /// </summary>
        UInt16 = 18,

        /// <summary>
        /// �����. 32 ����.
        /// </summary>
        UInt32 = 19,

        /// <summary>
        /// ������� �����. 64 ����.
        /// </summary>
        UInt64 = 21,

        /// <summary>
        /// �������� � ��������� ������. 32 ����.
        /// </summary>
        Real32 = 4,

        /// <summary>
        /// �������� � ��������� ������ ��������� ��������. 64 ����.
        /// </summary>
        Real64 = 5,

        /// <summary>
        /// ������ �������� � ������������� �����.
        /// </summary>
        String = 30,

        /// <summary>
        /// ����/�����. 80 ���.
        /// </summary>
        DateTime = 7,

        /// <summary>
        /// �������� ��� �������. ���� ����� ������� �� ������������, ��������� ������ ����� ����������� ���������.
        /// </summary>
        Array = 0x80,

        /// <summary>
        /// ������ ������� ��������.
        /// </summary>
        BooleanArray = Boolean | Array,

        /// <summary>
        /// ������ ���� �� ������.
        /// </summary>
        Int8Array = Int8 | Array,

        /// <summary>
        /// ������ �������� ����� ����� �� ������.
        /// </summary>
        Int16Array = Int16 | Array,

        /// <summary>
        /// ������ ����� ����� �� ������.
        /// </summary>
        Int32Array = Int32 | Array,

        /// <summary>
        /// ������ ������� ����� ����� �� ������.
        /// </summary>
        Int64Array = Int64 | Array,

        /// <summary>
        /// ������ ����.
        /// </summary>
        UInt8Array = UInt8 | Array,

        /// <summary>
        /// ������ �������� ����� �����.
        /// </summary>
        UInt16Array = UInt16 | Array,

        /// <summary>
        /// ������ ����� �����.
        /// </summary>
        UInt32Array = UInt32 | Array,

        /// <summary>
        /// ������ ������� ����� �����.
        /// </summary>
        UInt64Array = UInt64 | Array,

        /// <summary>
        /// ������ ����� � ��������� ������.
        /// </summary>
        Real32Array = Real32 | Array,

        /// <summary>
        /// ������ ����� � ��������� ������ ��������� ��������.
        /// </summary>
        Real64Array = Real64 | Array
    }
}