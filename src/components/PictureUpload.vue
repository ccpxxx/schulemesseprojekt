<template>
    <div class="flex justify-center items-center gap-4">
        <div class="pseudo-container overflow-hidden h-[429px] w-[429px] rounded-full bg-slate-200">
            <!-- <img class="picture  object-cover" :src="xaxa" /> -->
            <video class="h-full w-full" autoplay="true" id="videoElement" ref="video">
                <canvas id="canvas" width="429" height="429"></canvas>
</video>
<img :src="imgsrc" class="object-cover" style="position: absolute;
    height: 429px;
    width: 429px;
    border-radius: 100%;
    top: 48.5%;" />

        </div>
        <button @click="back">Back</button>
        <button @click="snap">Snap</button>
        <button @click="emitting">Emit</button>
    </div>
</template>

<script setup lang="ts">
import xaxa from "../assets/xaxa123.jpg"
import { triggerEvent } from "../utils/func";
const emit = defineEmits<(event: string, value: string) => void>()
const imgsrc = $ref("")
const emitting = () => {
    emit('picture', imgsrc)
}
const back = () => {
    triggerEvent(document.querySelector(".contact"), "click")
}


var video = $ref(document.querySelector("#videoElement"));

if (navigator.mediaDevices.getUserMedia) {
  navigator.mediaDevices.getUserMedia({ video: true })
    .then(function (stream) {
      video!.srcObject = stream;
    })
    .catch(function (err) {
      console.log("Something went wrong!", err);
    });
}

function snap() {
    let canvas = document.querySelector("#canvas") as HTMLCanvasElement;
   	canvas!.getContext('2d').drawImage(video, 0, 0, canvas.width, canvas.height);
   	let image_data_url = canvas.toDataURL('image/jpeg');
    imgsrc = image_data_url           
    // emit('picture', image_data_url)

   	// data url of the image
   	console.log(image_data_url);
}
</script>

<style scoped>


</style>
