import styled from "styled-components";
import foodImage from "../../assets/fatia-de-salmao-grelhado_144627-11117.jpg";

export const HeaderContainer = styled.header`
  background-image: url(${foodImage});
  background-size: cover;
  background-position: center;
  background-repeat: no-repeat;
  width: 100%;
  height: 250px;
  color: white;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;

  h2 {
    font-weight: bold;
    font-size: 40px;
    margin: 3px;
  }
`