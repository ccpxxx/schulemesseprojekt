<template>
  <main>
    <div class="container mt-8 mx-auto pl-4">
      <div class="w-1/2">
        <div class="w-full">

        
        <h1>{{ $t('messe.panel.intro') }}</h1>
        <h2>{{ $t('messe.panel.copy') }}</h2>
      </div>
      </div>
    </div>
    
    <TabWrapper :mode="mode">
      <TabVue title="Tab 1"><SignUp :obj="userObject" /></TabVue>
      <TabVue title="Tab 2"><ContactDetails :obj="userObject" /></TabVue>
      <TabVue title="Tab 3"><PictureUpload :obj="userObject" /></TabVue>
      <TabVue title="Tab 4"><Confirm :obj="userObject" /></TabVue>
    </TabWrapper>
    </main>
</template>

<script setup lang="ts">
// Props mit defineProps und einem typescript interface definieren.
// Über ein dekonstruiertes const können defaults definiert werden.
import TabWrapper from '../components/TabWrapper.vue';
import TabVue from '../components/Tab.vue';
import { castToVueI18n, I18nInjectionKey } from 'vue-i18n';
const userObject = $ref({ id: "2", name: "test" });
let mode = $ref('dark')
const changeStyle = () => {
  mode = mode === 'dark' ? 'light' : 'dark'
}
// Siehe auch: https://vuejs.org/guide/extras/reactivity-transform.html 
const { msg = "" } = defineProps<{ msg?: string }>()
const count = $ref(0)
</script>