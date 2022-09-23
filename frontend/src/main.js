import { createApp } from 'vue'
import App from './App.vue'
import {router} from './router/router'
// import './globalComponents'
import MButton from "@/components/base/button/MButton.vue"
import MDialog from "@/components/base/dialog/MDialog.vue"
import MInput from "@/components/base/input/MInput.vue"
import MToast from "@/components/base/toast/MToast.vue"
import MForm from "@/components/base/form/MForm.vue"
import MCheckbox from "@/components/base/checkbox/MCheckbox.vue"
import MCombobox from "@/components/base/combobox/MCombobox.vue"
import MComboboxDepartment from "@/components/base/combobox/MComboboxDepartment.vue"
import MOptions from "@/components/base/combobox/MOptions.vue"
import MTable from "@/components/base/table/MTable.vue"
import MPopup from "@/components/base/dialog/MPopup.vue"
import MInputRadioVue from "@/components/base/input/MInputRadio.vue";
import mitt from "mitt"

const app = createApp(App);
const emitter = mitt();
//Sử dụng global component

app.component("MButton", MButton);
app.component("MDialog", MDialog);
app.component("MInput",  MInput);
app.component("MToast",  MToast);
app.component("MForm", MForm)
app.component("MCheckbox" , MCheckbox)
app.component("MCombobox" , MCombobox)
app.component("MComboboxDepartment", MComboboxDepartment)
app.component("MOptions", MOptions)
app.component("MTable" , MTable)
app.component("MPopup" , MPopup)
app.component("MInputRadioVue", MInputRadioVue)


// Sử dụng eventbus
app.config.globalProperties.emitter = emitter;
//Sử dụng router
app.use(router)
app.mount('#app');