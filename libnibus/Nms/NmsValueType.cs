namespace NataInfo.Nibus.Nms
{
    public enum NmsValueType : byte
    {
        Boolean = 11, // 8 ��� �������� TRUE = 1/FALSE = 0
        Int8 = 16, // 8 ��� �������� ����
        Int16 = 2, // 16 ��� �������� �������� �����
        Int32 = 3, // 32 ���� �������� �����
        Int64 = 20, // 64 ���� �������� ������� �����
        UInt8 = 17, // 8 ��� ����
        UInt16 = 18, // 16 ��� �������� �����
        UInt32 = 19, // 32 ���� �����
        UInt64 = 21, // 64 ���� ������� �����
        Real32 = 4, // 32 ���� �������� � ��������� ������
        Real64 = 5, // 64 ���� �������� � ��������� ������ ��������� ��������
        String = 30, // ������ �������� � ������������� �����
        DateTime = 7,
        // 80 ��� ����/����� � ������� BCD
        // DD-MM-YYYY HH:MM:SS.0mmmbW
        // DD � ����
        // MM � �����
        // YYYY � ���
        // HH � ��� (0..23)
        // MM � ������
        // SS � �������
        // mmm � ������������
        // W � ���� ������ (1..7,
        // 1 � ��,
        // 2 � ��,
        // � 7 � ��)
        // b � ���������������
        Array = 0x80,
        BooleanArray = Boolean | Array,
        Int8Array = Int8 | Array,
        Int16Array = Int16 | Array,
        Int32Array = Int32 | Array,
        Int64Array = Int64 | Array,
        UInt8Array = UInt8 | Array,
        UInt16Array = UInt16 | Array,
        UInt32Array = UInt32 | Array,
        UInt64Array = UInt64 | Array,
        Real32Array = Real32 | Array,
        Real64Array = Real64 | Array
    }
}