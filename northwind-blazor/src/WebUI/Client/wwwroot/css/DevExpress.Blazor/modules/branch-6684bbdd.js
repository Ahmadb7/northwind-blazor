import{a as e}from"./_tslib-158249d5.js";import{n as t}from"./lit-element-d284a100.js";import{e as r,n}from"./property-ba1fa369.js";const a="dxbl-branch";class s{constructor(e,t,r){this._id=e,this._parentId=t,this._type=r}get parentId(){return this._parentId}get id(){return this._id}get type(){return this._type}}class c{constructor(e){this._id=e}get id(){return this._id}}class d extends CustomEvent{constructor(e){super(d.eventName,{detail:e,bubbles:!0,composed:!0})}}d.eventName="dxbranchrefreshed";class i extends CustomEvent{constructor(e){super(i.eventName,{detail:e,bubbles:!0,composed:!0})}}i.eventName="dxbranchactivated";class h extends CustomEvent{constructor(e){super(h.eventName,{detail:e,bubbles:!0,composed:!0})}}h.eventName="dxbranchupdated";class o extends CustomEvent{constructor(e){super(o.eventName,{detail:e,bubbles:!0,composed:!0})}}o.eventName="dxbranchremoved";class p extends CustomEvent{constructor(e){super(p.eventName,{detail:e,bubbles:!0,composed:!0})}}p.eventName="dxbranchcreated";let b=class extends t{constructor(){super(...arguments),this.parentBranchId=null}createRenderRoot(){return this}updated(e){this.branchId&&(e.get("branchId")||e.get("parentBranchId")||e.get("branchType"))&&this.raiseUpdated()}raiseUpdated(){const e=new s(this.branchId,this.parentBranchId,this.branchType),t=new h(e);this.dispatchEvent(t)}connectedCallback(){super.connectedCallback(),this.raiseCreated()}raiseCreated(){if(!this.branchId)return;const e=new s(this.branchId,this.parentBranchId,this.branchType),t=new p(e);this.dispatchEvent(t)}disconnectedCallback(){super.disconnectedCallback(),this.raiseRemoved()}raiseRemoved(){if(!this.branchId)return;const e=new s(this.branchId,this.parentBranchId,this.branchType),t=new o(e);this.dispatchEvent(t)}};function u(){}e([r({type:String,attribute:"branch-id"})],b.prototype,"branchId",void 0),e([r({type:String,attribute:"parent-branch-id"})],b.prototype,"parentBranchId",void 0),e([r({type:String,attribute:"type"})],b.prototype,"branchType",void 0),b=e([n("dxbl-branch")],b);const l={init:u,DxBranch:b,dxBranchTagName:"dxbl-branch",BranchUpdatedEvent:h};export{i as BranchActivatedEvent,p as BranchCreatedEvent,c as BranchIdContext,d as BranchRefreshedEvent,o as BranchRemovedEvent,h as BranchUpdatedEvent,l as default,a as dxBranchTagName,u as init};