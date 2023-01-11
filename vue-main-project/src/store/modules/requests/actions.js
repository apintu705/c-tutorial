export default {
  async contactCoach(context, payload) {
    const newRequest = {
      coachId: payload.coachId,
      userEmail: payload.email,
      message: payload.message,
    };
    const res = await fetch(
      `https://vue-http-18998-default-rtdb.firebaseio.com/requests/${payload.coachId}.json`,
      {
        method: 'POST',
        body: JSON.stringify(newRequest),
        headers: {
          contentType: 'application/json',
        },
      }
    );
    if (!res.ok) {
      const err = new Error(res.message);
      throw err;
    }

    const data = await res.json();

    newRequest.id = data.name;
    context.commit('addRequest', newRequest);
  },

  async fetchRequest(context) {
    const coachId = context.rootGetters.userId;
    const res = await fetch(
      `https://vue-http-18998-default-rtdb.firebaseio.com/requests/${coachId}.json`,
      {
        method: 'GET',
      }
    );
    if (!res.ok) {
      const error = new Error(res.message || 'falied to fetch requests');
      throw error;
    }
    const data = await res.json();

    const requests = [];

    for (const key in data) {
      const request = {
        id:key,
        coachId:coachId,
        userEmail:data[key].userEmail,
        message:data[key].message
      };
      requests.push(request);
    }
    context.commit('setRequest',requests);
  },
};
