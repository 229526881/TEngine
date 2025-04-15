using System.Collections.Generic;
using System.Reflection;
using GameLogic;
using TEngine;
#pragma warning disable CS0436


/// <summary>
/// 游戏App。
/// </summary>
public partial class GameApp
{
    private static List<Assembly> _hotfixAssembly;

    /// <summary>
    /// 热更域App主入口。
    /// </summary>
    /// <param name="objects"></param>
    public static void Entrance(object[] objects)
    {
        GameEventHelper.Init();
        _hotfixAssembly = (List<Assembly>)objects[0];
        Log.Warning("======= 看到此条日志代表你成功运行了热更新代码 =======");
        Log.Warning("======= Entrance GameApp =======");
        Utility.Unity.AddDestroyListener(Release);
        StartGameLogic();
    }
    
    private static void StartGameLogic()
    {
        GameEvent.Get<ILoginUI>().ShowLoginUI();
       // GameModule.UI.ShowUIAsync<BattleMainUI>();
        //GameModule.EcsModule.InitTypes(_hotfixAssembly);

        //一开始应该不需要加上棋盘
        //GameModule.MainScene.AddComponent<ChessBoard>();
        //GameModule.MainScene.AddComponent<ChessBoard>();
        
        //棋盘 此时已经是一个可以被使用的组件了或许，虽然还没被实例化
        //GameModule.MainScene.AddComponent<SaveModule>()
      //  GameModule.MainScene.AddComponent<SaveDataLogice>();
        GameModule.MainScene.AddComponent<ChessBoardRoot>();
    }
    
    private static void Release()
    {
        SingletonSystem.Release();
        Log.Warning("======= Release GameApp =======");
    }
}