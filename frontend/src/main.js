import { createApp } from 'vue'
import App from './App.vue'
import {router} from './router/router'
// import './globalComponents'

const app = createApp(App);
//Sử dụng global component
import MButton from "@/components/base/button/MButton.vue"
import MDialog from "@/components/base/dialog/MDialog.vue"
import MInput from "@/components/base/input/MInput.vue"
import MToast from "@/components/base/toast/MToast.vue"
import MForm from "@/components/base/form/MForm.vue"
import MCheckbox from "@/components/base/checkbox/MCheckbox.vue"
import MCombobox from "@/components/base/combobox/MCombobox.vue"
import MComboboxDepartment from "@/components/base/combobox/MComboboxDepartment.vue"
import MTable from "@/components/base/table/MTable.vue"
import MPopup from "@/components/base/dialog/MPopup.vue"
import MInputRadioVue from "@/components/base/input/MInputRadio.vue";



app.component("MButton", MButton);
app.component("MDialog", MDialog);
app.component("MInput",  MInput);
app.component("MToast",  MToast);
app.component("MForm", MForm)
app.component("MCheckbox" , MCheckbox)
app.component("MCombobox" , MCombobox)
app.component("MComboboxDepartment", MComboboxDepartment)
app.component("MTable" , MTable)
app.component("MPopup" , MPopup)
app.component("MInputRadioVue", MInputRadioVue)

// Sử dụng eventbus
app.config.globalProperties.$bus = createApp(App);
//Sử dụng router
app.use(router)
app.mount('#app');