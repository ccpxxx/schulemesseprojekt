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

     <div id="containers">
	<video ref="video" autoplay="true" id="videoElement">
	
	</video>
  <button class="p-4 text-red-400 m-4" @click="stop">Cheeeese</button>
</div>
    <TabWrapper :mode="mode">
      <TabVue title="Tab 1"><SignUp :obj="obj" /></TabVue>
      <TabVue title="Tab 2"><ContactDetails :obj="obj" /></TabVue>
      <TabVue title="Tab 3"><PictureUpload :obj="obj" /></TabVue>
      <TabVue title="Tab 4"><Confirm :obj="obj" /></TabVue>
    </TabWrapper>

   
    </main>
</template>

<script setup lang="ts">
// Props mit defineProps und einem typescript interface definieren.
// Über ein dekonstruiertes const können defaults definiert werden.
import TabWrapper from '../components/TabWrapper.vue';
import TabVue from '../components/Tab.vue';
import axios from "axios"
import UserObject from "../interfaces/UserObject"
import { castToVueI18n, I18nInjectionKey } from 'vue-i18n';
import { onMounted } from 'vue-demi';
const video = $ref(null)
onMounted(() => {
  if (navigator.mediaDevices.getUserMedia) {
  navigator.mediaDevices.getUserMedia({ video: true })
    .then(function (stream) {
      video.srcObject = stream;
    })
    .catch(function (err0r) {
      console.log("Something went wrong!");
    });
}
})
function stop(e: any) {
  var stream = video.srcObject;
  var tracks = stream.getTracks();

  for (var i = 0; i < tracks.length; i++) {
    var track = tracks[i];
    track.stop();
  }
}
const userObject = $ref({ id: "2", name: "test" });
let mode = $ref('dark')
const changeStyle = () => {
  mode = mode === 'dark' ? 'light' : 'dark'
}

// const x = await axios.get("https://localhost:13377/api/messe/getUsers")
const obj: UserObject = $ref({
  firstname: "Hans",
  name: "sss",
  id: 2,
  picture: "BLA"
})

// const test = await axios.post("https://localhost:13377/api/messe/submitcustomer", obj)
// console.log(test, "BLA")
// console.log(x, "X")
// Siehe auch: https://vuejs.org/guide/extras/reactivity-transform.html 
const { msg = "" } = defineProps<{ msg?: string }>()
const count = $ref(0)
</script>