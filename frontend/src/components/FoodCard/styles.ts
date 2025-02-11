import styled from "styled-components";

export const FoodCardContainer = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  align-items: flex-start;
  width: 100%;
  max-width: 250px;
  min-height: 350px;
  padding: 15px;
  background: #DAC8B3;
  border-radius: 8px;
  margin: 10px;
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);

  h4 {
    margin: 5px 0;
  }

  p {
    margin: 2px 0 10px;
  }

  div {
    margin-top: auto;
    width: 100%;
    display: flex;
    justify-content: center;
  }

  button {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 8px 12px;
    font-size: 14px;
    border-radius: 5px;
    cursor: pointer;
    transition: background-color 0.3s ease-in-out;

    &:hover {
      background-color: #0056b3;
    }
  }
`;
