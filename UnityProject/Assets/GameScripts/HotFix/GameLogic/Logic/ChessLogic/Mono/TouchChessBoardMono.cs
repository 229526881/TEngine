
using TEngine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameLogic
{
    public class TouchChessBoardMono:MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler
    {

        TouchChessBoardComponent component;
        public void InitConfig(TouchChessBoardComponent component)
        {
            this.component = component;
            
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            eventData.Use();
            component?.OnMouseDownChessBoard(eventData.pressPosition);
            Log.Debug("点击棋盘区");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            eventData.Use();
            component?.OnMouseUpChessBoard(eventData.pressPosition);
            Log.Debug("松手棋盘区");
        }

        public void OnDrag(PointerEventData eventData)
        {
            eventData.Use();
            Log.Debug("拖动棋盘区");
            component?.OnMouseMoveChessBoard(eventData.delta);
        }
    }
}