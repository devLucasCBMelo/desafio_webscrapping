import styled from "styled-components";

export const FooterContainer = styled.div`
  display: flex;
  flex-direction: row;
  width: 100%;
  background-color: rgb(30, 10, 12);
  color: white;
  justify-content: space-around;

  @media (max-width: 600px) {
    display: flex;
    flex-direction: column;
    align-items: center;

    p {
      margin: 5px 5px;
    }
  }
`