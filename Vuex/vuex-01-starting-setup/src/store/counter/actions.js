export default {
    increment(context) {
      setTimeout(() => {
        context.commit({ type: 'increment' });
      }, 2000);
    },
    increase(context, payload) {
      context.commit({ type: 'increase', payload });
    },
  }