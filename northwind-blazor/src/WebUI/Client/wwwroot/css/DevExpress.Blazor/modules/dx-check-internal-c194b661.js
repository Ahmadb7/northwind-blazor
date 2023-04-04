import{D as e}from"./dx-html-element-base-0df9d3c5.js";import"./data-qa-utils-8be7c726.js";import"./dom-9e6f7067.js";import"./_tslib-158249d5.js";import"./eventhelper-dec6cde0.js";var t;!function(e){e[e.Indeterminate=0]="Indeterminate",e[e.Checked=1]="Checked",e[e.Unchecked=2]="Unchecked"}(t||(t={}));class n extends e{constructor(){super(),this.boundOnInputChangeHandler=this.onInputChange.bind(this),this._checkState=t.Unchecked,this._allowIndeterminateStateByClick=!1}initializeComponent(){super.initializeComponent();this.getInputElement().addEventListener("change",this.boundOnInputChangeHandler)}afterInitialize(){super.afterInitialize(),this.applyCheckStateToElements()}disposeComponent(){super.disposeComponent();const e=this.getInputElement();e&&e.removeEventListener("change",this.boundOnInputChangeHandler)}get value(){return this.checkState===t.Indeterminate?"":Boolean(this.checkState===t.Checked).toString()}get checkState(){return this._checkState}set checkState(e){this._checkState!==e&&(this._checkState=e,this.applyCheckStateToElements())}get allowIndeterminateStateByClick(){return this._allowIndeterminateStateByClick}set allowIndeterminateStateByClick(e){this._allowIndeterminateStateByClick=e}getInputElement(){return this.querySelector("input")}getNextCheckState(){let e=this.checkState+1;return e>t.Unchecked&&(e=this.allowIndeterminateStateByClick?t.Indeterminate:t.Checked),e}onInputChange(e){this.checkState=this.getNextCheckState(),this.dispatchEvent(new Event("change",{bubbles:!0}))}applyCheckStateToElements(){if(!this.isInitialized)return;const e=this.getInputElement();e.indeterminate=this.checkState===t.Indeterminate,e.checked=this.checkState===t.Checked}static get observedAttributes(){return["check-state","allow-indeterminate-state-by-click"]}attributeChangedCallback(e,t,n){switch(e){case"check-state":this.checkState=parseInt(n);break;case"allow-indeterminate-state-by-click":this.allowIndeterminateStateByClick=null!==n}}}customElements.define("dxbl-check",n);const i={loadModule:function(){}};export{n as DxCheckInternal,i as default};
