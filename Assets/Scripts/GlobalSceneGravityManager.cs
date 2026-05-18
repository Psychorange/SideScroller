using UnityEngine;

public class GlobalSceneGravityManager : MonoBehaviour
{
    [SerializeField] SceneGravityManager AC;
    [SerializeField] SceneGravityManager CB;
    [SerializeField] SceneGravityManager BE;
    [SerializeField] SceneGravityManager BD;
    [SerializeField] SceneGravityManager JK;
    [SerializeField] SceneGravityManager DH;
    [SerializeField] SceneGravityManager DH2;
    [SerializeField] SceneGravityManager HJ;
    [SerializeField] SceneGravityManager FD;
    [SerializeField] SceneGravityManager IE;

    public void GlobalUpdate()
    {
        AC.UpdateSceneGravity();
        print("UPDATE AC");
        CB.UpdateSceneGravity();
        print("UPDATE CB");
        BE.UpdateSceneGravity();
        print("UPDATE BE");
        BD.UpdateSceneGravity();
        print("UPDATE BD");
        JK.UpdateSceneGravity();
        print("UPDATE JK");
        DH.UpdateSceneGravity();
        print("UPDATE DH");
        DH2.UpdateSceneGravity();
        print("UPDATE DH2");
        HJ.UpdateSceneGravity();
        print("UPDATE HJ");
        FD.UpdateSceneGravity();
        print("UPDATE FD");
        IE.UpdateSceneGravity();
        print("UPDATE IE");
    }
}
