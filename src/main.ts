import App from './App.vue'
import { ViteSSG } from 'vite-ssg'
import { RouteRecordRaw } from 'vue-router'
import { createI18n } from 'vue-i18n'
import './index.scss'
import HomeVue from './views/Home.vue'
import de from "./locales/de.json"
import ContactVue from './views/Contact.vue'

const i18n = createI18n({
    legacy: false,
    globalInjection: true,
    locale: "de",
    messages: { de }
})

const routes: RouteRecordRaw[] = [
    {
        path: '/',
        name: 'Home',
        component: App,
    }
]

export const createApp = ViteSSG(
    App,
    { routes },
    // hier normale vue Plugins aufrufen
    ({ app }) => { app.use(i18n)},
)