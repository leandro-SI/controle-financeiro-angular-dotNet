export interface MyToken {
  primarysid: string;
  unique_name: string;
  role: string;
  nbf: number;
  exp: number;
  iss: string;
  iat: number;
  aud: string;
}

// export interface MyToken {
//   id: string;
//   sub: string;
//   email: string;
//   name: string;
//   role: string;
//   jti: string;
//   nbf: number;
//   exp: number;
//   iat: number;
// }
