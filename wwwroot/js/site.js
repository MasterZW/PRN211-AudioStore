/**
 * LOGOUT PROCESS
 */
function logout() {
  let query = new QueryData("/account/logout");
  query.send("POST");
  query.addEvent("load", () => (window.location = "/"));
}
