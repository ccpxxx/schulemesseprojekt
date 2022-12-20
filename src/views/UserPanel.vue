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
      <TabVue title="Register"><SignUp :obj="userObject" /></TabVue>
      <TabVue title="Contact"><ContactDetails :obj="userObject" /></TabVue>
      <TabVue title="Picture"><PictureUpload @picture="switchTab" :obj="userObject" /></TabVue>
      <TabVue title="Confirm" ref="finalTab" :test="'test'"><Confirm  /><FinalCard :obj="userObject" /></TabVue>
    </TabWrapper>
    </main>
</template>

<script setup lang="ts">
// Props mit defineProps und einem typescript interface definieren.
// Über ein dekonstruiertes const können defaults definiert werden.
import TabWrapper from '../components/TabWrapper.vue';
import TabVue from '../components/Tab.vue';
import FinalCard from '../components/FinalCard.vue';
import logo from '../assets/logo.png';
import { triggerEvent } from '../utils/func';
import { castToVueI18n, I18nInjectionKey } from 'vue-i18n';
import { onMounted } from 'vue';
const userObject = $ref({ id: "2", name: "test", picture: logo });
let mode = $ref('dark')
const changeStyle = () => {
  mode = mode === 'dark' ? 'light' : 'dark'
}

function switchTab(logo: string): void  {
  userObject.picture = logo
  triggerEvent(document.querySelector(".confirm"), "click")


  
}
// Siehe auch: https://vuejs.org/guide/extras/reactivity-transform.html 
const { msg = "" } = defineProps<{ msg?: string }>()
const count = $ref(0)

function animatePicture() {
  const picture = document.querySelector(".picture")
  picture!.classList.add("animate__animated", "animate__bounceIn")
  setTimeout(() => {
    picture!.classList.remove("animate__animated", "animate__bounceIn")
  }, 2000);
}
</script>

<style>
.animate__animated {
  animation-duration: 1s;
  animation-fill-mode: both;
}
.animate__bounceIn {
  animation-name: bounceIn;
}
@keyframes bounceIn {
  0% {
    opacity: 0;
    transform: scale3d(.3, .3, .3);
  }

  50% {
    opacity: 1;
    transform: scale3d(1.05, 1.05, 1.05);
  }

  70% {
    transform: scale3d(.9, .9, .9);
  }

  100% {
    transform: scale3d(1, 1, 1);
  }
}



</style>