import{D as e}from"./dom-9e6f7067.js";import{T as n}from"./touch-585ccec1.js";import{d as t,r as o}from"./disposable-d2c2d283.js";import"./_tslib-158249d5.js";function s(t){let o=t;function s(n){o&&o.contains(n.srcElement)&&e.addClassName(o,"dxbs-focus-hidden")}function d(n){if(!o)return;const t=n.relatedTarget;t&&!o.contains(t)&&document.hasFocus()&&e.removeClassName(o,"dxbs-focus-hidden")}function c(n){o&&9===n.keyCode&&e.removeClassName(o,"dxbs-focus-hidden")}const r=document.documentElement;return r.addEventListener(n.touchMouseDownEventName,s),o.addEventListener("keydown",c),o.addEventListener("focusout",d),()=>{r.removeEventListener(n.touchMouseDownEventName,s,!0),null==o||o.removeEventListener("keydown",c,!0),null==o||o.removeEventListener("focusout",d),o=null}}function d(e){if(!e)return;t(e);const n=s(e);o(e,n)}const c={initFocusHidingEvents:d};export{s as attachEventsForFocusHiding,c as default,d as initFocusHidingEvents};