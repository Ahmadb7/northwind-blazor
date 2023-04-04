import{a as e}from"./_tslib-158249d5.js";import{B as t}from"./dom-9e6f7067.js";import o from"./adaptivedropdowncomponents-08231c47.js";import{D as n}from"./dx-dropdown-editor-base-4b1c3d3d.js";import{ListBoxSelectedItemsChangedEvent as r}from"./dx-listbox-11c22ed2.js";import{e as i}from"./property-ba1fa369.js";import"./dropdowncomponents-94a9238d.js";import"./popup-77a1ae4b.js";import"./rect-2684652a.js";import"./point-9c6ab88a.js";import"./rafaction-bba7928b.js";import"./transformhelper-3935ca6a.js";import"./layouthelper-c2462bd3.js";import"./positiontracker-9570b24e.js";import"./positiontrackerobserver-5fd93b2c.js";import"./supportcaptureelement-2f30b59b.js";import"./popuproot-4df55582.js";import"./branch-6684bbdd.js";import"./lit-element-d284a100.js";import"./data-qa-utils-8be7c726.js";import"./capturemanager-c228e074.js";import"./eventhelper-dec6cde0.js";import"./dx-ui-element-4d613bb9.js";import"./thumb-ae63786a.js";import"./query-44b9267f.js";import"./popupbasedialog-559fd684.js";import"./events-interseptor-b260a35a.js";import"./modalcomponents-026a9646.js";import"./dx-ui-handlers-bridge-4076ae57.js";import"./dx-dropdown-owner-2e57b57e.js";var d;!function(e){e.ContentOrEditorWidth="contentoreditorwidth",e.ContentWidth="contentwidth",e.EditorWidth="editorwidth"}(d||(d={}));class s extends n{constructor(){super(),this.boundOnKeyUpHandler=this.onKeyUp.bind(this),this.boundOnInputTextChangedHandler=this.onInputTextChanged.bind(this),this.boundOnDropDownSelectedItemsChangedHandler=this.onDropDownSelectedItemsChanged.bind(this),this.dropDownWidthMode=d.ContentOrEditorWidth,this.filteringEnabled=!1,this.dropDownWidthSourceResizeObserver=new ResizeObserver(this.onDropDownWidthSourceSizeChanged.bind(this))}get useMobileFocusBehaviour(){return t.MobileUI||super.useMobileFocusBehaviour}connectedCallback(){super.connectedCallback(),this.observeForDropDownWidthSourceElementSize(),this.addEventListener("keyup",this.boundOnKeyUpHandler),this.addEventListener("input",this.boundOnInputTextChangedHandler)}disconnectedCallback(){this.dropDownWidthSourceResizeObserver.disconnect(),this.removeEventListener("input",this.boundOnInputTextChangedHandler),this.removeEventListener("keyup",this.boundOnKeyUpHandler),super.disconnectedCallback()}updated(e){super.updated(e),e.has("dropDownWidthMode")&&this.prepareDropDownWidth()}onSlotChanged(e){super.onSlotChanged(e);const t=this.getDropDownWidthSourceElement();this.dropDownWidthSourceResizeObserver.observe(t)}invokeKeyDownServerCommand(e){var t,o;if(!this.requireSendKeyCommandToServer(e))return super.invokeKeyDownServerCommand(e);const n={key:e.key,altKey:e.altKey,ctrlKey:e.ctrlKey||e.metaKey,inputText:null===(t=this.inputElement)||void 0===t?void 0:t.value};return null===(o=this.uiHandlersBridge)||void 0===o||o.send("invokeKeyDownCommand",n),!0}processLostFocus(){var e,t;const o={text:null===(e=this.inputElement)||void 0===e?void 0:e.value};null===(t=this.uiHandlersBridge)||void 0===t||t.send("lostFocus",o)}onKeyUp(e){var t;if("ArrowUp"===e.key||"ArrowDown"===e.key){const o={key:e.key};null===(t=this.uiHandlersBridge)||void 0===t||t.send("invokeKeyUpCommand",o)}}onInputTextChanged(e){var t;if(!this.filteringEnabled||!this.inputElement)return;e.stopPropagation();null===(t=this.uiHandlersBridge)||void 0===t||t.send("invokeFilterChangedCommand",{text:this.inputElement.value})}onDropDownSelectedItemsChanged(e){e.stopPropagation();const t=e.target;null==t||t.scrollToFocusedItem(!1)}onDropDownWidthSourceSizeChanged(e,t){if(e.length<1||!this.dropDownElement)return;const o=e[0].contentRect.width+"px";this.dropDownElement.desiredWidth=this.dropDownWidthMode===d.EditorWidth?o:null,this.dropDownElement.minDesiredWidth=this.dropDownWidthMode===d.ContentOrEditorWidth?o:null}ensureDropDownElement(){var e;super.ensureDropDownElement(),null===(e=this.dropDownElement)||void 0===e||e.addEventListener(r.eventName,this.boundOnDropDownSelectedItemsChangedHandler)}disposeDropDownElement(){var e;null===(e=this.dropDownElement)||void 0===e||e.removeEventListener(r.eventName,this.boundOnDropDownSelectedItemsChangedHandler),super.disposeDropDownElement()}prepareDropDownWidth(){if(this.isInitialized)switch(this.dropDownWidthSourceResizeObserver.disconnect(),this.dropDownElement&&(this.dropDownElement.desiredWidth=null,this.dropDownElement.minDesiredWidth=null),this.dropDownWidthMode){case d.EditorWidth:case d.ContentOrEditorWidth:this.dropDownWidthSourceResizeObserver.observe(this.getDropDownWidthSourceElement())}}observeForDropDownWidthSourceElementSize(){this.dropDownWidthSourceResizeObserver.disconnect();const e=this.getDropDownWidthSourceElement();e&&this.dropDownWidthSourceResizeObserver.observe(e)}getDropDownWidthSourceElement(){return this.querySelector(".input-group")}requireSendKeyCommandToServer(e){switch(e.key){case"Enter":case"ArrowUp":case"ArrowDown":case"PageUp":case"PageDown":return!0;case"Home":case"End":return e.ctrlKey||e.metaKey}return!1}}e([i({type:d,attribute:"dropdown-width-mode"})],s.prototype,"dropDownWidthMode",void 0),e([i({type:Boolean,attribute:"filtering-enabled"})],s.prototype,"filteringEnabled",void 0),customElements.define("dxbl-combobox",s);const p={loadModule:function(){},adaptiveDropdownComponents:o};export{s as DxComboBox,p as default};