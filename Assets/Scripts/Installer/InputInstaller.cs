using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller<InputInstaller>
{
    [SerializeField] Player player;
    [SerializeField] MoveButton rightButton;
    [SerializeField] MoveButton leftButton;

    public override void InstallBindings()
    {
        // TODO:ここのBind Toをタッチ操作とキーボード操作で分ける
        // ボタンタッチ操作関連のBind
        Container.Bind<InputProviderBase>().To<TouchInputProvider>().AsSingle();
        Container.Bind<MoveButton>().WithId(MoveDirection.Right).FromInstance(rightButton).AsCached().IfNotBound();
        Container.Bind<MoveButton>().WithId(MoveDirection.Left).FromInstance(leftButton).AsCached().IfNotBound();

        // InputPresenterは誰からも参照されないのでNonLazyでBind
        Container.Bind<InputPresenter>().AsSingle().NonLazy();

        // PlayerはInspectorで指定したものをBindする
        Container.Bind<Player>().FromInstance(player).AsCached();
    }
}
