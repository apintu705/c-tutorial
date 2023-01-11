import { createApp } from "vue";

import App from "./App.vue";
import newFriend from "./components/NewFriend.vue"
import FriendContact from "./components/FriendContact.vue";
import activeUser from "./components/ActiveUser.vue"
import userData from "./components/UserData.vue"

const app = createApp(App);

app.component("friend-contact", FriendContact);
app.component("new-friend", newFriend)
app.component("active-user",activeUser);
app.component("user-data",userData);
app.mount("#app");
