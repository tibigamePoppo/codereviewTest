using System;
using DG.Tweening;

[Serializable]
public class EnemyDetail {
  public int EnemyId;
  public String Name;
  public String BackGround;
  public String Feature;
  public String Counter;
  public String Trace;
}

[Serializable]
public class Master {
  public EnemyDetail[] EnemyDetail;
}

