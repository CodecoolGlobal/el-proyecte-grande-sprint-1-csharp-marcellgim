import { useState } from 'react';
import Box from '@mui/material/Box';
import Stepper from '@mui/material/Stepper';
import Step from '@mui/material/Step';
import StepLabel from '@mui/material/StepLabel';
import StepContent from '@mui/material/StepContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Form from 'react-bootstrap/Form';
import 'bootstrap/dist/css/bootstrap.min.css';
import axiosInstance from "../fetch/axiosInstance";
function AddProduct({onCreate, handleClose}) {
  
  const [name, setName] = useState("");
  const [serviceInterval, setServiceInterval] = useState(0);
  const [warranty, setWarranty] = useState(0);
  const [imageFileName, setImageFileName] = useState("");
  const [imageData, setImageData] = useState("");

  const [shortDescription, setShortDescription] = useState("");
  const [longDescription, setLongDescription] = useState("");

  let url = `${process.env.REACT_APP_HOST_URL}/api/products`;

    const handleSubmit = async (e) => {
      e.preventDefault();
      const newProduct = {name, serviceInterval, warranty, imageFileName, shortDescription, longDescription, imageData};
      try {
        const response = await axiosInstance.post(url, newProduct)
        setName('');
      } catch (err) {
        console.log(`Error: ${err.message}`);
      }
      handleClose();
      onCreate(newProduct);
    }
    const fileToBase64 = (file, cb) => {
      const reader = new FileReader()
      reader.readAsDataURL(file)
      reader.onload = function () {
        cb(null, reader.result)
      }
      reader.onerror = function (error) {
        cb(error, null)
      }
  }
  const onUploadFileChange = ({ target }) => {
    if (target.files < 1 || !target.validity.valid) {
      return
    }
    fileToBase64(target.files[0], (err, result) => {
      if (result) {
        setImageData(result.split(',')[1])
        setImageFileName(target.files[0].name)
      }
    })
  }
  const [activeStep, setActiveStep] = useState(0);
  
  const handleNext = () => {
    setActiveStep((prevActiveStep) => prevActiveStep + 1);
  };

  const handleBack = () => {
    setActiveStep((prevActiveStep) => prevActiveStep - 1);
  };
    return ( 
                <Form onSubmit={handleSubmit}>
                  <Box sx={{ maxWidth: 400 }}>
      <Stepper activeStep={activeStep} orientation="vertical">
          <Step key="1">
            <StepLabel>Product data</StepLabel>
            <StepContent>
              <Typography>
        <Form.Label>
            Product name:
            <Form.Control type="text" onChange={(e) => setName(e.target.value)}/>
        </Form.Label>
        <Form.Label>
            Short description:
            <Form.Control type="text" onChange={(e) => setShortDescription(e.target.value)}/>
        </Form.Label>
        <Form.Label>
            Long description:
            <Form.Control as="textarea" rows={8} cols={22} onChange={(e) => setLongDescription(e.target.value)}/>
        </Form.Label>
        <Form.Label>
            Service interval:
            <Form.Control type="number" onChange={(e) => setServiceInterval(e.target.value)}/>
        </Form.Label>
        <Form.Label>
            Warranty:
            <Form.Control type="number" onChange={(e) => setWarranty(e.target.value)}/>
        </Form.Label>
        </Typography>
              <Box sx={{ mb: 2 }}>
                <div>
                  <Button variant="contained" onClick={handleNext} sx={{ mt: 1, mr: 1 }}>
                    Continue
                  </Button>
                </div>
              </Box>
            </StepContent>
          </Step>
          <Step key="2">
            <StepLabel>Product image</StepLabel>
            <StepContent>
              <Typography>
              <Form.Group controlId="formFile" className="mb-3">
    <Form.Label>Upload product image</Form.Label>
    <Form.Control type="file" onChange={onUploadFileChange} />
  </Form.Group>
              </Typography>
              <Box sx={{ mb: 2 }}>
                <div>
                  <Button variant="contained" type="submit" sx={{ mt: 1, mr: 1 }}>Create product</Button>
                  <Button onClick={handleBack} sx={{ mt: 1, mr: 1 }}>Back</Button>
                </div>
              </Box>
            </StepContent>
          </Step>
      </Stepper>
    </Box>
    </Form>
     );
}

export default AddProduct;