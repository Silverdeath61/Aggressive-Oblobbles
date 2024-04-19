using Modding;
using System.Collections;
using UnityEngine;
using HutongGames.PlayMaker;

namespace AgressiveOblobbles
{
    public class AgressiveOblobbles : Mod 
    {
        public override void Initialize()
        {
            On.GameManager.OnNextLevelReady += OblobbleRage; //Dont forget to call orig(self) :b
            Log("Initialized");
        }
        public void OblobbleRage( On.GameManager.orig_OnNextLevelReady orig, GameManager self ) 
        {
            if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "GG_Oblobbles")
            {
                orig(self);
                Patience patience = new();
                patience.Start();
            }
            else
            {
                orig(self);
            }
        }
        public class Patience : MonoBehaviour
        {
            public void Start()
            {
                GameManager.instance.StartCoroutine(WaitSome());
            }
            public IEnumerator WaitSome()
            {   
                yield return new WaitForSeconds(2f);
                GameObject mainBee = GameObject.Find("Mega Fat Bee");
                GameObject mainBee1 = GameObject.Find("Mega Fat Bee (1)");

                FsmEvent fetchedEvent = FsmEvent.FindEvent("ZERO HP");
                
                FSMUtility.SendEventToGameObject(mainBee, fetchedEvent);
                FSMUtility.SendEventToGameObject(mainBee1, fetchedEvent);
            }
        }
    }
}