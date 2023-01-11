import { createRouter, createWebHistory } from 'vue-router';

import CoachDetails from './pages/coaches/CoachesDetails.vue';
import CoachesList from './pages/coaches/CoachesList.vue';
import CoachRegistration from './pages/coaches/CoachRegistration.vue';
import ContactCoache from './pages/request/ContactCoach.vue';
import RequestRecieve from './pages/request/RequestRecieve.vue';
import NotFound from './pages/NotFound.vue';

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', redirect: '/coaches' },
    { path: '/coaches', component: CoachesList },
    {
      path: '/coaches/:id',
      component: CoachDetails,
      props:true,
      children: [{ path: 'contact', component: ContactCoache }],
    },
    { path: '/register', component: CoachRegistration },
    { path: '/request', component: RequestRecieve },
    { path: '/:notFound(.*)', component: NotFound },
  ],
});

export default router;
