import{c as e}from"./dom-utils-728879e5.js";import{defineDxCustomElement as t}from"./define-custom-element-ee3a9585.js";import"./dom-9e6f7067.js";import"./_tslib-158249d5.js";const s=document.createElement("style");s.type="text/css";class n extends HTMLElement{constructor(){super(),this.resourceStyleElement=s.cloneNode()}static get observedAttributes(){return["css"]}attributeChangedCallback(t,s,n){"css"===t&&async function(t,s){t&&await e((()=>s.innerHTML=t))}(n,this.resourceStyleElement)}connectedCallback(){this.resourceStyleElement.isConnected||document.head.appendChild(this.resourceStyleElement)}disconnectedCallback(){this.resourceStyleElement.isConnected&&this.resourceStyleElement.remove()}}t(customElements,"dxbl-dynamic-stylesheet",n);export{n as default};
