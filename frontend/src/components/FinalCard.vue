<template>
    <div class="card-container border gap-2 pl-4 border-cyan-200 grid grid-cols-2 prints">
        <div class="card-container__left flex p-4 justify-center rounded-full ">
            
                <img :src="obj.picture"
                class="moveIn h-[429px] w-[429px] object-cover rounded-full" alt="user picture " />
           
        </div>
        <div class="card-container__right p-4 flex justify-center flex-col">
            <div class="card-container__right__text border border-gray-800 rounded-sm w-full h-full flex gap-2 flex-col">
                <h2 v-if="obj.isOfficial" class="h-20 w-20 text-4xl">{{ $t('messe.official') }}</h2>
                <h2 class="h-20 w-20 text-4xl">{{ $t('messe.prename') + " " + obj.name }}</h2>
                <h2 class="h-20 w-20 text-4xl" >{{ $t('messe.name') + " " +  obj.lastName }}</h2>
                <h2 v-if="obj.interests" class="h-20 w-20 text-4xl">{{ $t('messe.interest') + " " }}
                
                {{ obj.interests.map(val => {
                    return val
                }).join(", ") }}</h2>
                

            </div>
    </div>
</div>
<button class="self-center bg-cyan-200 text-2xl font-bold p-2 rounded-sm" @click="print">{{ $t('messe.print') }}</button>

</template>

<script setup lang="ts">
import UserObject from '../interfaces/UserObject';


const props = defineProps<{ obj: UserObject }>()
const print = () => {
    window.print()
}
</script>

<style>
    .moveIn {
        animation: moveIn 1.5s ease-out;
        opacity: 1;
    }
    @keyframes moveIn {
        0% {
            
            transform:  translateX(150px);
        }
        100% {
            
            transform: translateY(0);
        }
    }
  

@media print {
    .test.wrapper-container.print:not( >  .prints) {
    
    display: none;
  }
}
</style>