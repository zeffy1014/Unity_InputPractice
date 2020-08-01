using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller<InputInstaller>
{
    [SerializeField] Player player = default;
    [SerializeField] MoveButton rightButton = default;
    [SerializeField] MoveButton leftButton = default;

    public override void InstallBindings()
    {
// 携帯端末用
#if UNITY_ANDROID || UNITY_IOS
        // ボタンタッチ操作関連のBind
        Container.Bind<InputProviderBase>().To<TouchInputProvider>().AsSingle();
        Container.Bind<MoveButton>().WithId(MoveDirection.Right).FromInstance(rightButton).AsCached().IfNotBound();
        Container.Bind<MoveButton>().WithId(MoveDirection.Left).FromInstance(leftButton).AsCached().IfNotBound();
// 携帯以外(PCなど)
#else
        // キーボード操作関連のBind
        Container.Bind<InputProviderBase>().To<PCInputProvider>().AsSingle();
        Container.Bind<KeyOperation>().FromNewComponentOnNewGameObject().AsCached();
#endif

        // InputPresenterは誰からも参照されないのでNonLazyでBind
        Container.Bind<InputPresenter>().AsSingle().NonLazy();

        // PlayerはInspectorで指定したものをBindする
        Container.Bind<Player>().FromInstance(player).AsCached();
    }
}
