public enum KokuchiType
{
    None,
    Yokushi,
    Tsuuchi,
    TsuuchiKaijo,
    Kaijo,
    Shuppatsu,
    ShuppatsuJikoku,
    Torikeshi,
    Tenmatsusho
}

public class KokuchiData
{
    public string DisplayData;
    public DateTime OriginTime;
    public KokuchiType Type;

    public KokuchiData(KokuchiType Type, string DisplayData, DateTime OriginTime)
    {
        this.Type = Type;
        this.DisplayData = DisplayData;
        this.OriginTime = OriginTime;
    }
}

public class EmergencyLightData
{
    public string Name;
    public bool State;
}

public enum Phase
{
    None,
    R,
    YY,
    Y,
    YG,
    G
}

public class SignalData
{
    public string Name;
    public Phase phase = Phase.None;
}

public class CarState
{
    public float Ampare;
    public float BC_Press;
    public string CarModel;
    public bool DoorClose;
    public bool HasConductorCab = false;
    public bool HasDriverCab = false;
    public bool HasMotor = false;
    public bool HasPantograph = false;
}

public class TrackCircuitData
{
    public string Last = null; //軌道回路を踏んだ列車の名前
    public string Name = "";
    public bool On = false;

    public override string ToString()
    {
        return $"{Name}/{Last}/{On}";
    }
}

public class DataToServer
{
    public int BNotch;
    public bool BougoState;
    public List<CarState> CarStates = new();
    public string DiaName;
    public List<TrackCircuitData> OnTrackList = null;

    public int PNotch;

    //将来用
    public float Speed;
}

public class DataFromServer
{
    //進路表示の表示はTC本体実装待ち　未決定
    public bool BougoState;
    public SignalData DoubleNextSignalData = null;
    public List<EmergencyLightData> EmergencyLightDatas;
    public Dictionary<string, KokuchiData> KokuchiData;
    public SignalData NextSignalData = null;
}