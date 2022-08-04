import React from 'react'
import { useState, useEffect } from 'react';
import useAuth from '../hooks/useAuth'
import useAxiosFetchGet from '../hooks/useAxiosFetchGet';
import jwtDecode from 'jwt-decode';
import { useNavigate } from "react-router-dom";
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Button from 'react-bootstrap/Button';
import Typography from '@mui/material/Typography';
import useAxios from '../hooks/useAxios';
import Form from 'react-bootstrap/Form';


const GET_USER_URL = "/api/users";
const POST_USER_URL = "/api/auth";


const UserProfile = () => {
  const { auth } = useAuth();
  const userId = jwtDecode(auth.accessToken).id;
  const { data: user } = useAxiosFetchGet(GET_USER_URL + `/${userId}`);
  let navigate = useNavigate();
  const axiosInstance = useAxios();
  const PWD_REGEX = /^.{8,24}$/;

  const [oldPassword, setOldPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [validPwd, setValidPwd] = useState(false);
  const [validMatch, setValidMatch] = useState(false);

  useEffect(() => {
    setValidPwd(PWD_REGEX.test(newPassword));
    setValidMatch(newPassword === confirmPassword);
  }, [newPassword, confirmPassword])

  const postData = async (data) => {
    const response = await axiosInstance.post(POST_USER_URL + `/${userId}`, data);
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    postData({
      username: user.userName,
      firstName: user.firstName,
      lastName: user.lastName,
      oldPassword: oldPassword,
      newPassword: newPassword
    });
  }

  return (
    <Card sx={{ maxWidth: 800 }}>
      <CardContent>
        <Typography gutterBottom variant="h3" component="div">
          Username: {user.userName}
        </Typography>
        <Typography gutterBottom variant="h6" component="div">
          First name: {user.firstName}
        </Typography>
        <Typography gutterBottom variant="h6" component="div">
          First name: {user.lastName}
        </Typography>
        <Typography gutterBottom variant="h6" component="div">
          First name: {user.role}
        </Typography>
      </CardContent>
      <Form onSubmit={handleSubmit}>
        <Form.Group>
          <Form.Label>Old password:</Form.Label>
          <Form.Control type="password" onChange={(e) => setOldPassword(e.target.value)} />
        </Form.Group>
        <Form.Group>
          <Form.Label>New password:</Form.Label>
          <Form.Control type="password" onChange={(e) => setNewPassword(e.target.value)} />
        </Form.Group>
        <Form.Group>
          <Form.Label>Confirm new password:</Form.Label>
          <Form.Control type="password" onChange={(e) => setConfirmPassword(e.target.value)} />
        </Form.Group>
        <Button variant="primary" type="submit" disabled={!validPwd || !validMatch} value="Change password">Change password</Button>
      </Form>
    </Card>
  );
}

export default UserProfile;