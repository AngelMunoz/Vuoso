<script setup>
import { inject } from "vue";
import Counter from "./Counter.fs"
import TextBased from "./TextBased.fs";
defineProps({
  msg: {
    type: String,
    required: true,
  },
});
const count = inject("count");
</script>

<template>
  <div class="greetings">
    <h1 class="green">{{ msg }}</h1>
    <h3>
      <p>This is a .vue file component with it's "count" being injected from an F# vue render function.</p>
      <p>
        This comes from the Fable side:
        <span class="green bigger">{{ count }}</span>
      </p>
      <Counter :initial="100" />
      <TextBased />
    </h3>
  </div>
</template>

<style scoped>
h1 {
  font-weight: 500;
  font-size: 2.6rem;
}

h3 {
  font-size: 1.2rem;
}

.greetings h1,
.greetings h3 {
  text-align: center;
}

@media (min-width: 1024px) {
  .greetings h1,
  .greetings h3 {
    text-align: left;
  }
}
</style>
