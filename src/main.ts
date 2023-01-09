import App from './App.vue'
import { ViteSSG } from 'vite-ssg'
import { RouteRecordRaw, createRouter, createWebHistory } from 'vue-router'
import { createI18n } from 'vue-i18n'
import './index.scss'
import HomeVue from './views/Home.vue'
import de from "./locales/de.json"
import en from "./locales/en.json"
import AdminVue from './views/Admin.vue'
import HelloWorldVue from './views/UserPanel.vue'
import TabWrapperVue from './components/TabWrapper.vue'
import UserPanelVue from './views/UserPanel.vue'

export const i18n = createI18n({
    legacy: false,
    globalInjection: true,
    locale: "de",
    messages: { de, en }
})

const routes: RouteRecordRaw[] = [
    {
        path: '/',
        name: 'Home',
        component: HelloWorldVue,
        beforeEnter: reset
    },
    {
        path: '/admin',
        name: 'Admin',
        beforeEnter : guardMyroute,
        component: AdminVue,
    },
    {
        path: '/userpanel',
        name: 'UserPanel',
        component: UserPanelVue,
    }
]

const router = createRouter({
    history: createWebHistory(),
    routes,
  });
  
export const createApp = ViteSSG(
    App,
    { routes },
    // hier normale vue Plugins aufrufen
    ({ app, router }) => { app.use(i18n, router)},
)

function guardMyroute(to: any, from: any, next: (arg0: any | undefined) => void)
{
 var isAuthenticated= false;
 if(localStorage.getItem('loggedUser'))
  isAuthenticated = true;
 else
  isAuthenticated= false;
if(isAuthenticated) {
  next(); // allow to enter route
 } else{
  next('/'); // go to '/login';
 }
}

function reset() {
    localStorage.clear()
}