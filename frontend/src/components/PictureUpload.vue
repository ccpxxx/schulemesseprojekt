<template>
    <div class="flex justify-center items-center gap-4">
        <div class="pseudo-container  relative overflow-hidden h-[429px] w-[429px] rounded-full bg-slate-200" >
            <!-- <img class="picture  object-cover" :src="xaxa" /> -->
            <video class="h-full w-full" autoplay="true" id="videoElement" ref="video">
                <canvas id="canvas" width="429" height="429"></canvas>
</video>
<img :src="imgsrc" class="" style="position: absolute;
    /* height: 429px;
    width: 429px; */
    border-radius: 100%;
    top: 0;" />

        </div>
        <button class="p-4 bg-red-400" @click="snap">{{ $t('messe.takePhoto') }}</button>
        <button class="p-4 bg-green-800" @click="emitting">{{ $t('messe.emit') }}</button>
        <button class="p-4 bg-yellow-400" @click="newPicture">{{ $t('messe.newPicture') }}</button>
    </div>
    <button class="send p-4 bg-green-400" @click="back">{{ $t('messe.back') }}</button>
</template>

<script setup lang="ts">
import { triggerEvent } from "../utils/func";
const emit = defineEmits<(event: string, value: string) => void>()
const imgsrc = $ref("")
const emitting = () => {
    if(!imgsrc) {
        alert( "$t('messe.pleasePicFirst')" )
        return
    }
    emit('picture', imgsrc)
}
const back = () => {
    triggerEvent(document.querySelector(".contact"), "click")
}


const video = $ref(null);

if (navigator.mediaDevices.getUserMedia) {
  navigator.mediaDevices.getUserMedia({ video: true })
    .then(function (stream) {
      video!.srcObject = stream;
    })
    .catch(function (err) {
      console.log("Something went wrong!", err);
    });
}
function newPicture() {
    let canvas = document.querySelector("#canvas") as HTMLCanvasElement;
    canvas!.getContext('2d').clearRect(0, 0, canvas.width, canvas.height);
    imgsrc = ""
}
function snap() {
    let canvas = document.querySelector("#canvas") as HTMLCanvasElement;
   	canvas!.getContext('2d').drawImage(video, 0, 0, canvas.width, canvas.height);
   	let image_data_url = canvas.toDataURL('image/jpeg');
    imgsrc = image_data_url           
    // emit('picture', image_data_url)

   	// data url of the image
}
</script>

<style scoped>


</style>
