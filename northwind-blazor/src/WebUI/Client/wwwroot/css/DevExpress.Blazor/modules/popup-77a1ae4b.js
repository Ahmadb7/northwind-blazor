import{a as t}from"./_tslib-158249d5.js";import{a as e,S as i,R as o}from"./rect-2684652a.js";import{R as s}from"./rafaction-bba7928b.js";import{P as n,a as r}from"./point-9c6ab88a.js";import{T as a}from"./transformhelper-3935ca6a.js";import{L as h}from"./layouthelper-c2462bd3.js";import{PositionChangingEvent as l}from"./positiontracker-9570b24e.js";import{P as c}from"./positiontrackerobserver-5fd93b2c.js";import{a as d,b as p,P as u,c as m,d as g,D as b,V as f}from"./supportcaptureelement-2f30b59b.js";import{BranchActivatedEvent as v,BranchIdContext as y}from"./branch-6684bbdd.js";import{a as w,c as C}from"./capturemanager-c228e074.js";import{E as P}from"./eventhelper-dec6cde0.js";import{B as T,v as R,b as H,p as L}from"./popuproot-4df55582.js";import{L as E,i as x}from"./dx-ui-element-4d613bb9.js";import{r as O,y as B}from"./lit-element-d284a100.js";import{e as N,n as S}from"./property-ba1fa369.js";const z=new class{constructor(){this._x=0,this._y=0,this.handlePointerDown=this.pointerEventHandler.bind(this)}get x(){return this._x}get y(){return this._y}subscribe(){window.addEventListener("pointerdown",this.handlePointerDown,{capture:!0,passive:!0}),window.addEventListener("pointermove",this.handlePointerDown,{capture:!0,passive:!0}),window.addEventListener("pointerup",this.handlePointerDown,{capture:!0,passive:!0})}unsubscribe(){window.removeEventListener("pointerdown",this.handlePointerDown),window.removeEventListener("pointermove",this.handlePointerDown),window.removeEventListener("pointerup",this.handlePointerDown)}pointerEventHandler(t){this._x=t.pageX,this._y=t.pageY}};z.subscribe();class I{constructor(t,e){this.xField=t,this.yField=e}get x(){return this.xField}get y(){return this.yField}}I.zero=new I(0,0);class D{static add(t,e){return new I(t.x+e.x,t.y+e.y)}static multiply(t,e){return new I(t.x*e,t.y*(1/e))}static divide(t,e){return new I(t.x*(1/e),t.y*(1/e))}static getLength(t){return Math.sqrt(t.x*t.x+t.y*t.y)}static normalize(t){const e=Math.max(Math.abs(t.x),Math.max(t.y)),i=D.divide(t,e);return D.divide(i,D.getLength(i))}}class M{static viewport(){return new e(window.scrollX,window.scrollY,document.documentElement.clientWidth,document.documentElement.clientHeight)}static page(){return new e(0,0,document.body.clientWidth,document.body.clientHeight)}}class A{constructor(t,e){this.target=null,this.targetMutationObserver=new MutationObserver((t=>this.handleTargetMutations.bind(this))),this.observedElement=null,this.selector=t,this.callback=e}get hasObservedElement(){return null!==this.observedElement}observe(t=null){this.disconnect(),this.target=t;const e=null!=t?t:document;this.observedElement=e.querySelector(this.selector),this.observedElement&&this.raiseElementChanged(null,this.observedElement),this.targetMutationObserver.observe(e,{subtree:!0,childList:!0})}disconnect(){this.targetMutationObserver.disconnect()}raiseElementChanged(t,e){this.callback({oldElement:t,element:e},this)}handleTargetMutations(t,e){this.hasObservedElement?this.processRemovedNodes(t):this.processAddedNodes(t)}processRemovedNodes(t){this.processRemovedNodesInternal(t)&&(this.raiseElementChanged(this.observedElement,null),this.observedElement=null)}processRemovedNodesInternal(t){return t.forEach((t=>{t.removedNodes.forEach((t=>{if(this.observedElement===t)return!0}))})),!1}processAddedNodes(t){const[e,i]=this.processAddedNodesInternal(t);e&&(this.raiseElementChanged(this.observedElement,i),this.observedElement=i)}processAddedNodesInternal(t){var e;const i=(null!==(e=this.target)&&void 0!==e?e:document).querySelector(this.selector);return[null!==i,i]}}var F;var _,W,k,V,q,j,$;!function(t){t.Viewport="viewport",t.Page="page",t.Rectangle="rectangle",t.TargetElement="targetelement"}(_||(_={})),function(t){t.None="none",t.Hide="hide",t.Close="close"}(W||(W={})),function(t){t[t.TopLeft=0]="TopLeft",t[t.TopRight=1]="TopRight",t[t.BottomLeft=2]="BottomLeft",t[t.BottomRight=3]="BottomRight",t[t.Center=4]="Center"}(k||(k={}));class U{constructor(t,e){this.targetInterestPoint=t,this.childInterestPoint=e}}!function(t){t.Absolute="absolute",t.Relative="relative",t.Bottom="bottom",t.Center="center",t.Right="right",t.AbsolutePoint="absolutepoint",t.RelativePoint="relativepoint",t.Mouse="mouse",t.MousePoint="mousepoint",t.Left="left",t.Top="top",t.Custom="custom"}(V||(V={})),function(t){t.Near="near",t.Far="far"}(q||(q={})),function(t){t.top="top",t.bottom="bottom"}(j||(j={})),function(t){t[t.None=0]="None",t[t.Horizontal=1]="Horizontal",t[t.Vertical=2]="Vertical"}($||($={}));class K{constructor(t=new n(0,0),e=new i(0,0)){this.childSize=i.Empty,this.mousePosition=null,this.visuallyHidden=!1,this.closingRequested=!1,this.lockPlacement=!1,this.lockedPosition=0,this.topLeft=t,this.size=e}}class X{constructor(t,e,i,o,s){this.dropOpposite=!1,this.dropDirection=q.Near,this.dropAlignment=j.bottom,this.axis=e,this.point=t,this.dropOpposite=i,this.dropAlignment=s,this.dropDirection=o}}class Y{constructor(t,e){this.customPlacement=null,this._childPoints=t,this._placementTargetPoints=e}get childPoints(){return this._childPoints}get placementTargetPoints(){return this._placementTargetPoints}}class G extends CustomEvent{constructor(t){super(G.eventName,{detail:t,bubbles:!0,composed:!1,cancelable:!0})}}G.eventName="dxbl-popup-custom-placement";class J{}class Q extends CustomEvent{constructor(t){super(Q.eventName,{detail:t,bubbles:!0,composed:!1,cancelable:!0})}}Q.eventName="dxbl-popup-shown";class Z extends CustomEvent{constructor(t){super(Z.eventName,{detail:t,bubbles:!0,composed:!1,cancelable:!0})}}Z.eventName="dxbl-popup-closed";let tt=F=class extends d{constructor(){super(),this._renderedVisible=!1,this.hasOwnLogicalParent=!1,this.tolerance=.01,this.repositionAction=new s,this.positionInfo=new K,this._child=null,this.childResizeObserver=new ResizeObserver(this.handleChildSizeChanged.bind(this)),this._dropOpposite=!1,this._dropFromRight=!1,this._offset=n.zero,this.placementTargetElementField=null,this.positionChangingHandler=this.handlePositionChanging.bind(this),this.sizeChangedHandler=this.handleSizeChanged.bind(this),this.placementTargetPositionChangedHandler=this.handlePlacementTargetPositionChanged.bind(this),this.placementTargetPositionObserver=new c(this.placementTargetPositionChangedHandler,{raf:!1}),this.placementTargetElementChangedHandler=this.handlePlacementTargetElementChanged.bind(this),this.placementTargetObserver=null,this._autoFocus=!1,this._interceptor=null,this.bridgeSlotChangedHandler=this.handleBridgeSlotChange.bind(this),this.closingResultRequestedTcs=new p,this._positionChangedEvent=new w,this._parentPopup=null,this.positionChangedHandler=this.handleParentPopupPositionChanged.bind(this),this.closeOnOutsideClick=!1,this.preventCloseOnPositionTargetClick=!1,this.closeMode=W.Hide,this.fitToRestriction=!1,this.preventInteractions=!1,this.hasServerSideClosing=!1,this.parentBranchId=null,this.rootCssStyle=null,this.placement=V.Absolute,this.horizontalOffset=0,this.verticalOffset=0,this.placementTarget=null,this.restrictTarget=null,this.restrict=_.Viewport,this.width=null,this.maxWidth=null,this.minWidth=null,this.height=null,this.maxHeight=null,this.minHeight=null,this.desiredWidth=null,this.desiredHeight=null,this.minDesiredWidth=null,this.minDesiredHeight=null,this.renderWidth=null,this.renderHeight=null,this.restrictRectangle=e.Empty,this.placementRectangle=e.Empty,this.actualDropDirection=q.Near,this.actualDropAlignment=j.bottom,this.actualDropOpposite=!1,this._isOpen=!1,this.resizing=!1}get branchType(){return T.DropDown}get positionChanged(){return this._positionChangedEvent}static get styles(){return O`
            :host {
                display: flex;
                flex: 1 1 auto;
                flex-direction: column;
                min-height: 0;
            }
            dxbl-branch {
                display: flex;
                flex: 1 1 auto;
                flex-direction: column;
                min-height: 0;
            }
            .content-holder {
                display: flex;
                flex: 1 0 auto;
                flex-direction: column;
                min-height: 0;
            }
        `}get renderedVisible(){var t,e;return this._renderedVisible&&(null===(e=null===(t=this._parentPopup)||void 0===t?void 0:t.renderedVisible)||void 0===e||e)}updated(t){t.has("closeOnOutsideClick")&&this.processCapture(this.closeOnOutsideClick),this.reposition()}get child(){return this._child}get isOpen(){return this._isOpen}get placementTargetElement(){return this.placementTargetElementField}set placementTargetElement(t){this.unsubscribeFromPlacementTargetPositionObserver(),this.placementTargetElementField=t,this.subscribeToPlacementTargetPositionObserver()}get dropOpposite(){return this._dropOpposite}get autoFocus(){return this._autoFocus}get dropFromRight(){return this._dropFromRight}get offset(){return this._offset}set offset(t){this._offset=t,this.style.transform=a.translateByPoint(t)}get childSize(){return this.positionInfo.childSize}render(){return this.renderTemplate()}willUpdate(t){if(this.renderWidth=this.calcRenderWidth(),this.renderHeight=this.calcRenderHeight(),this.shouldUpdateRootCssStyle(t)){let t="";this.shouldCalcWidth()&&(t+=`width: ${this.calcWidth()}; `),this.shouldCalcMinWidth()&&(t+=`min-width: ${this.calcMinWidth()}; `),this.shouldCalcMaxWidth()&&(t+=`max-width: ${this.calcMaxWidth()}; `),this.shouldCalcHeight()&&(t+=`height: ${this.calcHeight()}; `),this.shouldCalcMinHeight()&&(t+=`min-height: ${this.calcMinHeight()}; `),this.shouldCalcMaxHeight()&&(t+=`max-height: ${this.calcMaxHeight()}; `),this.rootCssStyle=t}}calcRenderHeight(){var t;return null!==(t=this.desiredHeight)&&void 0!==t?t:this.height}calcRenderWidth(){var t;return null!==(t=this.desiredWidth)&&void 0!==t?t:this.width}calcMaxWidth(){return this.maxWidth}calcMaxHeight(){return this.maxHeight}calcMinWidth(){var t;return null!==(t=this.minDesiredWidth)&&void 0!==t?t:this.minWidth}calcMinHeight(){var t;return null!==(t=this.minDesiredHeight)&&void 0!==t?t:this.minHeight}shouldCalcMinHeight(){return!!this.minHeight||!!this.minDesiredHeight}shouldCalcMinWidth(){return!!this.minWidth||!!this.minDesiredWidth}shouldCalcMaxWidth(){return!!this.maxWidth}shouldCalcMaxHeight(){return!!this.maxHeight}shouldCalcWidth(){return!!this.renderWidth}shouldCalcHeight(){return!!this.renderHeight}calcWidth(){return this.renderWidth}calcHeight(){return this.renderHeight}shouldUpdateRootCssStyle(t){return t.has("width")||t.has("minWidth")||t.has("maxWidth")||t.has("height")||t.has("minHeight")||t.has("maxHeight")||t.has("desiredWidth")||t.has("desiredHeight")||t.has("renderWidth")||t.has("renderHeight")||t.has("minDesiredWidth")||t.has("minDesiredHeight")}renderTemplate(){return B`
            <div class="${this.rootCssStyle}">
                ${this.renderSlot}
            </div>
        `}renderSlot(){return B`
            ${this.renderDefaultSlot()}
            ${this.renderAdditionalSlots()}
            ${this.renderBridgeSlot()}
        `}renderDefaultSlot(){return B`<slot></slot>`}renderBridgeSlot(){return B`
            <slot name="bridge" @slotchange=${this.bridgeSlotChangedHandler}></slot>
        `}renderAdditionalSlots(){return B`
            <slot name="top-left" slot="top-left"></slot>
            <slot name="top-right" slot="top-right"></slot>
            <slot name="bottom-left" slot="bottom-left"></slot>
            <slot name="bottom-right" slot="bottom-right"></slot>
        `}firstUpdated(){this.child&&(this.childResizeObserver.observe(this.child),this.reposition())}connectedCallback(){super.connectedCallback()}disconnectedCallback(){super.disconnectedCallback(),this.close()}handleBridgeSlotChange(t){const e=t.target.assignedNodes();this._interceptor=e[0]}async processCapturedPointerDownAsync(t,e){e.handled||(e.nextInteractionHandled=e.nextInteractionHandled||this.preventInteractions,u.containsInComposedPath(t,this)||this.shouldCloseOnPlacementTargetClick(t)||await m.processCapturedPointerDown(this,t,e))}shouldCloseOnPlacementTargetClick(t){return!(!this.preventCloseOnPositionTargetClick||!this.placementTargetElement)&&P.containsInComposedPath(t,(t=>t===this.placementTargetElement))}async closeAsync(t,e){const i=await this.raiseClosingResultRequestedAsync(e);return this.closingResultRequestedTcs=new p,t.nextInteractionHandled=t.nextInteractionHandled||this.preventInteractions,t.handled=!0,Promise.resolve(!!i)}async closeHierarchyAsync(t,e,i){await m.closeHierarchyAsync(this,t,e,i)}async closeRootAsync(t,e,i){await m.closeRootAsync(this,t,e,i)}async processCapturedKeyDownAsync(t,e){if(await super.processCapturedKeyDownAsync(t,e),!e.handled&&"Escape"===t.key){P.markHandled(t);const i=await this.raiseClosingResultRequestedAsync(g.EscapePress);if(this.closingResultRequestedTcs=new p,!i)return void(e.handled=!0);C.releaseCapture(this)}}lostCapture(){super.lostCapture()}gotCapture(){super.gotCapture(),this.activate()}raiseEvent(t,e){var i;null===(i=this._interceptor)||void 0===i||i.raise(t,e)}unsubscribeFromPlacementTargetObserver(){this.placementTargetObserver&&(this.placementTargetObserver.disconnect(),this.placementTargetObserver=null)}subscribeToPlacementTargetObserver(){this.isOpen&&(this.placementTargetObserver=new A(this.placementTarget,this.placementTargetElementChangedHandler),this.placementTargetObserver.observe())}unsubscribeFromPlacementTargetPositionObserver(){this.placementTargetPositionObserver.disconnect()}subscribeToParentPopup(){const t=E.findParent(this,(t=>x(t,(()=>["closeHierarchyAsync","closeAsync","processCapturedPointerDownAsync","addEventListener","removeEventListener","contains","focus","positionChanged","renderedVisible"]))));if(t&&x(t,(()=>["closeHierarchyAsync","closeAsync","processCapturedPointerDownAsync","addEventListener","removeEventListener","contains","focus","positionChanged","renderedVisible"]))){const e=t;e.positionChanged.subscribe(this.positionChangedHandler),this._parentPopup=e}}unsubscribeFromParentPopup(){this._parentPopup&&(this._parentPopup.positionChanged.unsubscribe(this.positionChangedHandler),this._parentPopup=null)}handleParentPopupPositionChanged(t,e){this.updatePosition()}subscribeToPlacementTargetPositionObserver(){this.placementTargetElement&&this.isOpen&&this.placementTargetPositionObserver.observe(this.placementTargetElement)}show(){this.isOpen||(this._isOpen=!0,this.raiseShown(),this.addToLogicalTree(),this.addToVisibleBranchTree(),this.subscribeEvents(),this.initializeCapture(),this.reposition())}ensureBranchId(){if(!this.branchId)throw new Error("branchId should not be null")}addToVisibleBranchTree(){this.ensureBranchId(),R.register(this.branchId)}removeFromVisibleBranchTree(){this.ensureBranchId(),R.unregister(this.branchId)}raiseShown(){const t=new J;this.dispatchEvent(new Q(t))}raiseClosed(){const t=new J;this.dispatchEvent(new Z(t))}close(){this.isOpen&&(this._isOpen=!1,this.raiseClosed(),this.removeFromLogicalTree(),this.removeFromVisibleBranchTree(),this.unsubscribeEvents(),this.releaseCapture(),this.cleanUpAfterClose(),this.reposition())}notifyCloseCanceled(){this.processClosingRequested(!1),this.positionInfo.closingRequested=!1}cleanUpAfterClose(){this.updateVisibility(!1),this.positionInfo=new K}shouldCapture(){return this.closeOnOutsideClick||this.preventInteractions}addToLogicalTree(){if(this.hasLogicalParent)return void(this.hasOwnLogicalParent=!0);this.ensureBranchId();const t=H.getParentId(this.branchId),e=L.getPopup(t);e&&x(e,(()=>["logicalChildren","addLogicalChild","removeLogicalChild"]))&&e.addLogicalChild(this)}removeFromLogicalTree(){if(this.hasOwnLogicalParent)return void(this.hasOwnLogicalParent=!1);const t=E.getParent(this,!0);t&&x(t,(()=>["logicalChildren","addLogicalChild","removeLogicalChild"]))&&t.removeLogicalChild(this)}initializeCapture(){this.shouldCapture&&C.capture(this)}releaseCapture(){this.processClosingRequested(!0),C.releaseCapture(this)}processClosingRequested(t){this.closingResultRequestedTcs.resolve(t),this.closingResultRequestedTcs=new p,this.positionInfo.closingRequested=!1}subscribeToChild(t){t&&this.childResizeObserver.observe(t,{box:"border-box"})}unsubscribeFromChild(t){t&&this.childResizeObserver.unobserve(t)}subscribeEvents(){document.addEventListener(l.eventName,this.positionChangingHandler),this.addEventListener(l.eventName,this.positionChangingHandler),window.addEventListener("resize",this.sizeChangedHandler),this.subscribeToPlacementTargetObserver(),this.subscribeToPlacementTargetPositionObserver(),this.subscribeToParentPopup()}unsubscribeEvents(){document.removeEventListener(l.eventName,this.positionChangingHandler),this.removeEventListener(l.eventName,this.positionChangingHandler),this.removeEventListener("resize",this.sizeChangedHandler),this.unsubscribeFromPlacementTargetPositionObserver(),this.unsubscribeFromPlacementTargetObserver(),this.unsubscribeFromParentPopup()}reposition(){this.repositionAction.execute(this.updatePosition.bind(this))}activate(){const t=new v(new y(this.branchId));this.dispatchEvent(t)}forceReposition(){this.repositionAction.cancel(),this.updatePosition()}lockPlacement(){this.positionInfo.lockPlacement=!0}unlockPlacement(){this.positionInfo.lockPlacement=!1}handleChildSizeChanged(t,e){this.reposition()}handlePositionChanging(t){this.reposition()}handleSizeChanged(t){this.reposition()}handlePlacementTargetPositionChanged(t,e){this.reposition()}handlePlacementTargetElementChanged(t,e){this.placementTargetElement=t.element,this.reposition()}isAbsolutePlacementMode(t){switch(t){case V.MousePoint:case V.Mouse:case V.AbsolutePoint:case V.Absolute:return!0}return!1}interestPointsFromRect(t){const e=new Array(5);return e[k.TopLeft]=t.topLeft,e[k.TopRight]=t.topRight,e[k.BottomLeft]=t.bottomLeft,e[k.BottomRight]=t.bottomRight,e[k.Center]=new n(t.x+t.width/2,t.y+t.height/2),e}getPlacementTargetInterestPoints(t){let s,a=e.Empty;const l=this.placementTargetElement,c=new I(this.horizontalOffset,this.verticalOffset);if(!l||this.isAbsolutePlacementMode(t))t!==V.Mouse&&t!==V.MousePoint||(this.positionInfo.mousePosition||(this.positionInfo.mousePosition=new n(z.x,z.y)),a=e.create(this.positionInfo.mousePosition,i.Empty)),a=o.offset(a,c),s=this.interestPointsFromRect(a);else{a=this.placementRectangle,o.areSame(a,e.Empty)&&(a=t!==V.Relative&&t!==V.RelativePoint?new e(0,0,l.offsetWidth,l.offsetHeight):e.Empty),a=o.offset(a,c),s=this.interestPointsFromRect(a);const i=h.getRelativeElementRect(l).topLeft;for(let t=0;t<5;t++)s[t]=r.add(s[t],i)}return s}getChildInterestPoints(t){return this.interestPointsFromRect(this.child?new e(0,0,this.child.offsetWidth,this.child.offsetHeight):e.Empty)}getBounds(t){let i=t[0].x,o=t[0].x,s=t[0].y,n=t[0].y;return t.forEach((t=>{const e=t.x,r=t.y;e<i&&(i=e),e>o&&(o=e),r<s&&(s=r),r>n&&(n=r)})),new e(i,s,o-i,n-s)}raiseCustomPlacement(t,e){const i=new G(new Y(t,e));return this.dispatchEvent(i),i.detail.customPlacement}getNumberOfCombinations(t){switch(t){case V.Mouse:return 2;case V.Bottom:case V.Top:case V.Right:case V.Left:case V.RelativePoint:case V.MousePoint:case V.AbsolutePoint:return 4;case V.Custom:return 0;default:return 1}}getPointCombination(t,e){const i=this.dropFromRight;switch(t){case V.Mouse:if(i){if(0===e)return[new U(k.BottomRight,k.TopRight),$.Horizontal,!1,q.Near,j.bottom];if(1===e)return[new U(k.TopRight,k.BottomRight),$.Horizontal,!1,q.Near,j.bottom]}else{if(0===e)return[new U(k.BottomLeft,k.TopLeft),$.Horizontal,!1,q.Near,j.bottom];if(1===e)return[new U(k.TopLeft,k.BottomLeft),$.Horizontal,!1,q.Near,j.bottom]}break;case V.Bottom:if(i){if(0===e)return[new U(k.BottomRight,k.TopRight),$.Horizontal,!1,q.Far,j.bottom];if(1===e)return[new U(k.TopRight,k.BottomRight),$.Horizontal,!0,q.Far,j.top];if(2===e)return[new U(k.BottomLeft,k.TopLeft),$.Horizontal,!1,q.Near,j.bottom];if(3===e)return[new U(k.TopLeft,k.BottomLeft),$.Horizontal,!0,q.Near,j.top]}else{if(0===e)return[new U(k.BottomLeft,k.TopLeft),$.Horizontal,!1,q.Near,j.bottom];if(1===e)return[new U(k.TopLeft,k.BottomLeft),$.Horizontal,!0,q.Near,j.top];if(2===e)return[new U(k.BottomRight,k.TopRight),$.Horizontal,!1,q.Far,j.bottom];if(3===e)return[new U(k.TopRight,k.BottomRight),$.Horizontal,!0,q.Far,j.top]}break;case V.Top:if(i){if(0===e)return[new U(k.TopRight,k.BottomRight),$.Horizontal,!1,q.Far,j.top];if(1===e)return[new U(k.BottomRight,k.TopRight),$.Horizontal,!0,q.Far,j.bottom];if(2===e)return[new U(k.TopLeft,k.BottomLeft),$.Horizontal,!1,q.Near,j.top];if(3===e)return[new U(k.BottomLeft,k.TopLeft),$.Horizontal,!0,q.Near,j.bottom]}else{if(0===e)return[new U(k.TopLeft,k.BottomLeft),$.Horizontal,!1,q.Near,j.top];if(1===e)return[new U(k.BottomLeft,k.TopLeft),$.Horizontal,!0,q.Near,j.bottom];if(2===e)return[new U(k.TopRight,k.BottomRight),$.Horizontal,!1,q.Far,j.top];if(3===e)return[new U(k.BottomRight,k.TopRight),$.Horizontal,!0,q.Far,j.bottom]}break;case V.Right:case V.Left:if(i&&t===V.Right||!i&&t===V.Left){if(0===e)return[new U(k.TopLeft,k.TopRight),$.Vertical,!1,q.Near,j.bottom];if(1===e)return[new U(k.BottomLeft,k.BottomRight),$.Vertical,!0,q.Near,j.top];if(2===e)return[new U(k.TopRight,k.TopLeft),$.Vertical,!1,q.Far,j.bottom];if(3===e)return[new U(k.BottomRight,k.BottomLeft),$.Vertical,!0,q.Far,j.top]}else{if(0===e)return[new U(k.TopRight,k.TopLeft),$.Vertical,!1,q.Near,j.bottom];if(1===e)return[new U(k.BottomRight,k.BottomLeft),$.Vertical,!0,q.Near,j.top];if(2===e)return[new U(k.TopLeft,k.TopRight),$.Vertical,!1,q.Far,j.bottom];if(3===e)return[new U(k.BottomLeft,k.BottomRight),$.Vertical,!0,q.Far,j.top]}break;case V.Relative:case V.RelativePoint:case V.MousePoint:case V.AbsolutePoint:if(i){if(0===e)return[new U(k.TopLeft,k.TopRight),$.Horizontal,!1,q.Far,j.bottom];if(1===e)return[new U(k.TopLeft,k.TopLeft),$.Horizontal,!1,q.Near,j.bottom];if(2===e)return[new U(k.TopLeft,k.BottomRight),$.Horizontal,!0,q.Far,j.top];if(3===e)return[new U(k.TopLeft,k.BottomLeft),$.Horizontal,!0,q.Near,j.top]}else{if(0===e)return[new U(k.TopLeft,k.TopLeft),$.Horizontal,!1,q.Near,j.bottom];if(1===e)return[new U(k.TopLeft,k.TopRight),$.Horizontal,!1,q.Far,j.bottom];if(2===e)return[new U(k.TopLeft,k.BottomLeft),$.Horizontal,!0,q.Near,j.top];if(3===e)return[new U(k.TopLeft,k.BottomRight),$.Horizontal,!0,q.Far,j.top]}break;case V.Center:return[new U(k.Center,k.Center),$.None,!1,q.Near,j.bottom];default:return[new U(k.TopLeft,k.TopLeft),$.None,!1,q.Near,j.bottom]}return[new U(k.TopLeft,k.TopLeft),$.None,!1,q.Near,j.bottom]}getRestrictBounds(){switch(this.restrict){case _.Viewport:return M.viewport();case _.Page:return M.page();case _.TargetElement:{if(!this.restrictTarget)throw new Error("restrictTarget should be specified if restrictmode is custom");const t=document.querySelector(this.restrictTarget);return h.getRelativeElementRect(t)}case _.Rectangle:return this.restrictRectangle}return M.viewport()}updatePosition(){if(!this.isOpen)return this._renderedVisible=!1,void(this.style.display=b.none);const t=this.renderedVisible;this._renderedVisible=!0;const e=this.renderedVisible;if(!e)return this.updateVisibility(!0),void(t!==e&&this.raisePositionChanged(this.offset,!1));this.style.display=b.flex;const i=this.placement,s=this.getPlacementTargetInterestPoints(i),a=this.getChildInterestPoints(i),h=this.getBounds(s);let l=this.getBounds(a);const c=l.width*l.height;let d=-1,p=new I(this.positionInfo.topLeft.x,this.positionInfo.topLeft.y),u=!1,m=-1,f=$.None,v=0,y=this.actualDropDirection,w=this.actualDropOpposite,C=this.actualDropAlignment,P=null;i===V.Custom?(P=this.processCustomPlacement(a,s),v=P?P.length:0):v=this.getNumberOfCombinations(i);for(let t=0;t<v;t++){if(this.positionInfo.lockPlacement&&this.positionInfo.lockedPosition!==t)continue;let e=new I(0,0),n=$.None,h=!1,u=q.Near,g=j.bottom;if(i===V.Custom){const i=P[t];e=D.add(s[k.TopLeft],i.point),n=i.axis,h=i.dropOpposite,u=i.dropDirection,g=i.dropAlignment}else{const[o,n,l,c,d]=this.getPointCombination(i,t);h=l,u=c,g=d,e=r.sub(s[o.targetInterestPoint],a[o.childInterestPoint])}const b=o.offset(l,e),v=this.getRestrictBounds(),T=o.intersect(v,b),R=T.isEmpty?0:T.width*T.height;if(R-m>this.tolerance&&(d=t,p=e,m=R,f=n,y=u,w=h,C=g,Math.abs(R-c)<this.tolerance))break}this.actualDropOpposite=w,this.actualDropDirection=y,this.actualDropAlignment=C,l=o.offset(l,p);const T=this.getRestrictBounds(),R=o.intersect(T,l);[p,u]=this.calcRestrictedBestTranslation(R,l,s,T,h,p),this.processBestTranslationResults(p,l,h,w,y,C,f),this.positionInfo.lockedPosition=d,this.positionInfo.childSize=l.size;const H=Math.round(p.x),L=Math.round(p.y);let E=!1;H===this.positionInfo.topLeft.x&&L===this.positionInfo.topLeft.y||(this.positionInfo.topLeft=new n(H,L),this.offset=this.positionInfo.topLeft,E=!0);const x=!e||u,O=this.updateVisibility(x);E=E||O,E&&this.raisePositionChanged(this.offset,x),this.closeMode===W.Close&&!this.positionInfo.closingRequested&&x&&(this.positionInfo.closingRequested=!0,this.raiseClosingRequested(g.Programmatically))}raisePositionChanged(t,e){this._positionChangedEvent.raise(this,[!e,t])}updateVisibility(t){return this._renderedVisible=!t,this.positionInfo.visuallyHidden!==t&&(this.style.visibility=t?f.hidden:f.visible,this.positionInfo.visuallyHidden=t,!0)}processCustomPlacement(t,e){return this.raiseCustomPlacement(t,e)}raiseClosingRequested(t){this.raiseEvent("closingRequested",{closeReason:t})}raiseClosingResultRequested(t){this.raiseEvent("closingResultRequested",{closeReason:t})}async raiseClosingResultRequestedAsync(t){return this.hasServerSideClosing?(this.closingResultRequestedTcs=new p,this.raiseClosingResultRequested(t),this.closingResultRequestedTcs.promise):(this.raiseClosingRequested(t),!0)}calcRestrictedBestTranslation(t,e,i,o,s,n){return[this.fitToRestriction?this.calcRestrictedFitBestTranslation(t,e,i,o,n):n,this.closeMode!==W.None&&this.calcRestrictedShouldHide(o,s)]}calcRestrictedShouldHide(t,e){if(!this.placementTargetElement)return!F.checkTargetEdgesWithin(t,e);let i=t;return h.getClippingParents(this.placementTargetElement).forEach((t=>{const e=h.getRelativeElementRect(t);i=o.intersect(i,e)})),!!i.isEmpty||!F.checkTargetEdgesWithin(i,e)}static checkTargetEdgesWithin(t,e){return o.contains(t,e.topLeft)||o.contains(t,e.topRight)||o.contains(t,e.bottomLeft)||o.contains(t,e.bottomRight)}calcRestrictedFitBestTranslation(t,e,i,o,s){if(Math.abs(t.width-e.width)>this.tolerance||Math.abs(t.height-e.height)>this.tolerance){const t=i[k.TopLeft],n=r.sub(i[k.TopRight],t),a=D.normalize(new I(n.x,n.y));Number.isNaN(a.y)||Math.abs(a.y)<this.tolerance?e.right>o.right?s=new I(o.right-e.width,s.y):e.left<o.left&&(s=new I(o.left,s.y)):Math.abs(a.x)<this.tolerance&&(e.bottom>o.bottom?s=new I(s.x,o.bottom-e.bottom):e.top<o.top&&(s=new I(s.x,o.top)));const h=r.sub(t,i[k.BottomLeft]),l=D.normalize(h);Number.isNaN(l.x)||Math.abs(l.x)<this.tolerance?e.bottom>o.bottom?s=new I(s.x,o.bottom-e.height):e.top<o.top&&(s=new I(s.x,o.top)):Math.abs(l.y)<this.tolerance&&(e.right>o.right?s=new I(o.right-e.width,s.y):e.left<o.left&&(s=new I(o.x,s.y)))}return s}processCapture(t){}processBestTranslationResults(t,e,i,o,s,n,r){}};function et(){}function it(t){return t}t([N({type:Boolean,attribute:"close-on-outside-click"})],tt.prototype,"closeOnOutsideClick",void 0),t([N({type:Boolean,attribute:"prevent-close-on-position-target-click"})],tt.prototype,"preventCloseOnPositionTargetClick",void 0),t([N({type:String,attribute:"close-mode"})],tt.prototype,"closeMode",void 0),t([N({type:Boolean,attribute:"fit-to-restriction"})],tt.prototype,"fitToRestriction",void 0),t([N({type:Boolean,attribute:"prevent-interactions"})],tt.prototype,"preventInteractions",void 0),t([N({type:Boolean,attribute:"has-serverside-closing"})],tt.prototype,"hasServerSideClosing",void 0),t([N({type:String,attribute:"branch-id"})],tt.prototype,"branchId",void 0),t([N({type:String,attribute:"parent-branch-id"})],tt.prototype,"parentBranchId",void 0),t([N({type:String,reflect:!1})],tt.prototype,"rootCssStyle",void 0),t([N({type:String,attribute:"placement"})],tt.prototype,"placement",void 0),t([N({type:Number,attribute:"horizontal-offset"})],tt.prototype,"horizontalOffset",void 0),t([N({type:Number,attribute:"vertical-offset"})],tt.prototype,"verticalOffset",void 0),t([N({type:String,attribute:"placement-target"})],tt.prototype,"placementTarget",void 0),t([N({type:String,attribute:"restrict-target"})],tt.prototype,"restrictTarget",void 0),t([N({type:String,attribute:"restrict"})],tt.prototype,"restrict",void 0),t([N({type:String,attribute:"width"})],tt.prototype,"width",void 0),t([N({type:String,attribute:"max-width"})],tt.prototype,"maxWidth",void 0),t([N({type:String,attribute:"min-width"})],tt.prototype,"minWidth",void 0),t([N({type:String,attribute:"height"})],tt.prototype,"height",void 0),t([N({type:String,attribute:"max-height"})],tt.prototype,"maxHeight",void 0),t([N({type:String,attribute:"min-height"})],tt.prototype,"minHeight",void 0),t([N({type:String,attribute:"desired-width"})],tt.prototype,"desiredWidth",void 0),t([N({type:String,attribute:"desired-height"})],tt.prototype,"desiredHeight",void 0),t([N({type:String,attribute:"min-desired-width"})],tt.prototype,"minDesiredWidth",void 0),t([N({type:String,attribute:"min-desired-height"})],tt.prototype,"minDesiredHeight",void 0),t([N({type:String,reflect:!1})],tt.prototype,"renderWidth",void 0),t([N({type:String,reflect:!1})],tt.prototype,"renderHeight",void 0),t([N({type:String,attribute:"restrict-rect",converter:t=>t?o.parse(t):e.Empty})],tt.prototype,"restrictRectangle",void 0),t([N({type:String,attribute:"placement-rect",converter:t=>t?o.parse(t):e.Empty})],tt.prototype,"placementRectangle",void 0),t([N({type:String,attribute:"x-drop-direction",reflect:!0})],tt.prototype,"actualDropDirection",void 0),t([N({type:String,attribute:"x-drop-alignment",reflect:!0})],tt.prototype,"actualDropAlignment",void 0),t([N({type:String,attribute:"x-drop-opposite",reflect:!0,converter:{toAttribute:(t,e)=>t?"true":"false"}})],tt.prototype,"actualDropOpposite",void 0),t([N({type:Boolean,attribute:"x-is-open",reflect:!0,converter:{fromAttribute:(t,e)=>{throw new Error("readonly")}}})],tt.prototype,"_isOpen",void 0),t([N({type:Boolean,attribute:"resizing"})],tt.prototype,"resizing",void 0),tt=F=t([S("dxbl-popup")],tt);const ot=Object.freeze({__proto__:null,dxPopupTagName:"dxbl-popup",get CloseMode(){return W},get InterestPoint(){return k},get PlacementMode(){return V},get DropDirection(){return q},get DropAlignment(){return j},get PopupPrimaryAxis(){return $},CustomPopupPlacement:X,CustomPlacementEvent:G,PopupContext:J,PopupShownEvent:Q,PopupClosedEvent:Z,get DxPopup(){return tt},init:et,getReference:it,default:{init:et,getReference:it,dxPopupTagName:"dxbl-popup",DxPopup:tt}});export{X as C,tt as D,k as I,Q as P,I as V,q as a,j as b,Z as c,V as d,$ as e,ot as p};
