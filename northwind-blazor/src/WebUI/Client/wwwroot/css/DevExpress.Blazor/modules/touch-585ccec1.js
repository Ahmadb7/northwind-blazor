import{b as e,a as o}from"./dom-9e6f7067.js";var t=function(){function t(){}return t.onEventAttachingToDocument=function(o,n){return!e.Browser.MacOSMobilePlatform||!t.isTouchEventName(o)||(t.documentTouchHandlers[o]||(t.documentTouchHandlers[o]=[]),t.documentTouchHandlers[o].push(n),t.documentEventAttachingAllowed)},t.isTouchEventName=function(o){return e.Browser.WebKitTouchUI&&(o.indexOf("touch")>-1||o.indexOf("gesture")>-1)},t.isTouchEvent=function(t){return e.Browser.WebKitTouchUI&&o.isDefined(t.changedTouches)},t.getEventX=function(o){return e.Browser.IE?o.pageX:o.changedTouches[0].pageX},t.getEventY=function(o){return e.Browser.IE?o.pageY:o.changedTouches[0].pageY},t.touchMouseDownEventName=e.Browser.WebKitTouchUI?"touchstart":e.Browser.Edge&&e.Browser.MSTouchUI&&window.PointerEvent?"pointerdown":"mousedown",t.touchMouseUpEventName=e.Browser.WebKitTouchUI?"touchend":e.Browser.Edge&&e.Browser.MSTouchUI&&window.PointerEvent?"pointerup":"mouseup",t.touchMouseMoveEventName=e.Browser.WebKitTouchUI?"touchmove":e.Browser.Edge&&e.Browser.MSTouchUI&&window.PointerEvent?"pointermove":"mousemove",t.msTouchDraggableClassName="dxMSTouchDraggable",t.documentTouchHandlers={},t.documentEventAttachingAllowed=!0,t}(),n=Object.defineProperty({TouchUtils:t},"__esModule",{value:!0});export{t as T,n as t};
