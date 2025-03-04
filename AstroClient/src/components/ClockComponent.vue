<template>
  <div id="app">
    <h1>Hora Actual</h1>
    <p>{{ time }}</p>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { HubConnectionBuilder } from '@microsoft/signalr';

// Definir una variable reactiva para almacenar la hora
const time = ref('');

// Crear una nueva conexión con SignalR
const connection = new HubConnectionBuilder()
  .withUrl('http://localhost:5000/clockHub') // URL del Hub SignalR
  .build();

// Definir lo que sucederá cuando el servidor envíe la hora
connection.on('ReceiveTime', (currentTime) => {
  time.value = currentTime; // Actualizar la hora recibida
});

// Iniciar la conexión cuando el componente se monte
onMounted(() => {
  connection.start()
    .then(() => {
      console.log('Conexión a SignalR establecida.');
    })
    .catch((err) => {
      console.error('Error al conectar con SignalR: ', err);
    });
});
</script>

<style>
#app {
  text-align: center;
  margin-top: 50px;
}
</style>
