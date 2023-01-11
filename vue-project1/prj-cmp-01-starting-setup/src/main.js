import { createApp } from 'vue';
import App from './App.vue';
import BaseCard from './Components/ui/BaseCard.vue';
import BaseButton from './Components/ui/BaseButton.vue';
import BaseDialog from './Components/ui/BaseDialog.vue';


const app = createApp(App);

app.component('base-card', BaseCard);
app.component('base-button', BaseButton);
app.component('base-dialog', BaseDialog);

app.mount('#app');
