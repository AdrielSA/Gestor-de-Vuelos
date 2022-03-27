const baseUrl = process.env.REACT_APP_UrlAPI;

export const getall = `${baseUrl}/api/vuelos/getall`;
export const get = `${baseUrl}/api/vuelos/get/`;
export const add = `${baseUrl}/api/vuelos/add`;
export const update = `${baseUrl}/api/vuelos/update/`;
export const remove = `${baseUrl}/api/vuelos/delete/`;

export const login = `${baseUrl}/api/usuarios/login`;
export const register = `${baseUrl}/api/usuarios/register`;