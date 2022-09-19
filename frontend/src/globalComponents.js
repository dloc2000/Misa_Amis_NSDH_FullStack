import App from "./App.vue"
import { createApp } from 'vue'
import MButton from "@/components/base/button/MButton.vue"
import MDialog from "@/components/base/dialog/MDialog.vue"
import MInput from "@/components/base/input/MInput.vue"
import MToast from "@/components/base/toast/MToast.vue"

const app = createApp(App);


app.component("MButton", MButton);
app.component("MDialog", MDialog);
app.component("MInput",  MInput);
app.component("MToast",  MToast);
