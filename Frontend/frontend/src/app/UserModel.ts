export class UserModel {
    id: string;
    name: string;
    mail: string;
  
    constructor(id: string = '', name: string = '', mail: string = '') {
      this.id = id;
      this.name = name;
      this.mail = mail;
    }
  }
  