using UnityEngine;

public class TapeBackgroundController : BaseController
{
    public TapeBackgroundController(IReadOnlySubscribeProperty<float> leftMove,
        IReadOnlySubscribeProperty<float> rightMove)
    {
        _view = LoadView();
        _diff = new SubscribeProperty<float>();

        _leftMove = leftMove;
        _rightMove = rightMove;

        _view.Init(_diff);

        _leftMove.SubscribeOnChange(Move);
        _rightMove.SubscribeOnChange(Move);
    }

    private readonly ResourcesPath _viewPath = new ResourcesPath { PathResources = "Prefabs/Background" };
    private TapeBackgroundView _view;
    private readonly SubscribeProperty<float> _diff;
    private readonly IReadOnlySubscribeProperty<float> _leftMove;
    private readonly IReadOnlySubscribeProperty<float> _rightMove;

    protected override void OnDispose()
    {
        _leftMove.UnSubscribeOnChange(Move);
        _rightMove.UnSubscribeOnChange(Move);

        base.OnDispose();
    }

    private TapeBackgroundView LoadView()
    {
        var objView = Object.Instantiate(ResourcesLoader.LoadPrefab(_viewPath));
        AddGameObject(objView);

        return objView.GetComponent<TapeBackgroundView>();
    }

    private void Move(float value)
    {
        _diff.Value = value;
    }
}
