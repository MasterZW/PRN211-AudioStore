class QueryData {
  constructor(path, type) {
    this.xhr = new XMLHttpRequest();
    this.params = new URLSearchParams();
    this.xhr.responseType = type || "";
    this.link = `${path}`;
  }

  addEvent(eventType, func, ...args) {
    this.xhr.addEventListener(eventType, func, args);
  }

  addParam(key, value) {
    this.params.append(key, value);
  }

  send(method) {
    if (method === "GET") {
      this.xhr.open(method, `${this.link}?${this.params.toString()}`);
      this.xhr.send();
    } else if (method === "POST") {
      this.xhr.open(method, this.link);
      this.xhr.send(this.params);
    } else {
      throw "Only accept GET and POST";
    }
  }
}

class QueryUpload {
  constructor(path) {
    this.xhr = new XMLHttpRequest();
    this.params = new FormData();
    this.link = `${path}`;
  }

  addEvent(eventType, func, ...args) {
    if (eventType === "load") this.xhr.addEventListener(eventType, func, args);
    else this.xhr.upload.addEventListener(eventType, func, args);
  }

  addParam(key, value) {
    this.params.append(key, value);
  }

  send() {
    this.xhr.open("POST", this.link);
    this.xhr.send(this.params);
  }
}
