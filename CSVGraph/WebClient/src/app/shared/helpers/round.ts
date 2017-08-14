

export const round = (value, decimals) =>
   Number(Math.round(value + <any>'e' + decimals) + 'e-' + decimals);
