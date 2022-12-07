import App from './App.vue'
import { ViteSSG } from 'vite-ssg'
import { RouteRecordRaw } from 'vue-router'
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
    },
    {
        path: '/admin',
        name: 'Admin',
        component: AdminVue,
    },
    {
        path: '/userpanel',
        name: 'UserPanel',
        component: UserPanelVue,
    }
]

export const createApp = ViteSSG(
    App,
    { routes },
    // hier normale vue Plugins aufrufen
    ({ app }) => { app.use(i18n)},
)